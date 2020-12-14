using System;
using System.Collections; 
using System.Collections.Generic;
using System.IO;

namespace day_12
{
    public class Instruction 
    {
        public char Inst {get; set;} 
        public int Amount {get; set;} 

        public Instruction(char instruction, int amount)
        {
            this.Inst = instruction; 
            this.Amount = amount; 
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            List<string> data = new List<string>();
            string testInput = "./test_input.txt";
            string questionInput = "./input.txt"; 
            //parse(testInput, ref data); 
            parse(questionInput, ref data); 
            List<Instruction> instructions = new List<Instruction>(); 
            parseIntoDictionary(data, instructions);
            move(instructions);
            partII(instructions); 
        }

        public static void parse(string file, ref List<string> data) 
        {
            if(data == null) return; 
            if(file == null) return; 
            string[] lines = File.ReadAllLines(file);
            foreach(string s in lines) 
            {
                data.Add(s);
            }
        }

        public static void parseIntoDictionary(List<string> data, List<Instruction> instructions) 
        {
            string num = "";
            int amt = 0; 
            foreach(string i in data) 
            {
                char d = i[0];  
                num = i.Substring(1); 
                amt = 0; 
                Int32.TryParse(num, out amt);
                instructions.Add(new Instruction(d, amt));
            }
        }    

        public static void move(List<Instruction> instructions) 
        {
            int[] facing = { 'N', 'E', 'S', 'W' }; 
            uint facingIndex = 1;
            int north = 0; 
            int east = 0; 
            int south = 0; 
            int west = 0; 
            foreach (Instruction i in instructions) 
            {
                 if (i.Inst == 'F') 
                 {
                    if (facingIndex == 0) north += i.Amount; 
                    if (facingIndex == 3) west += i.Amount; 
                    if (facingIndex == 2) south += i.Amount;  
                    if (facingIndex == 1) east += i.Amount;   
                 }
                 if (i.Inst == 'N') north += i.Amount; 
                 if (i.Inst == 'E') east += i.Amount; 
                 if (i.Inst == 'S') south += i.Amount; 
                 if (i.Inst == 'W') west += i.Amount; 
                 if (i.Inst == 'L') facingIndex = GetFacing(facingIndex, i.Amount, i.Inst);
                 if (i.Inst == 'R') facingIndex = GetFacing(facingIndex, i.Amount, i.Inst); 
            }
            int northSouth = Math.Abs(north - south);
            int eastwest = Math.Abs(east - west); 
            int tot = eastwest + northSouth;
            System.Console.WriteLine("Final Location {0} + {1} = {2}", northSouth, eastwest, tot);
        }

        public static void partII(List<Instruction> instructions)
        {
                            // X, y
            int[] wayPointPos = {10, 1}; 
            int[] shipPos = {0, 0}; 
            foreach (Instruction i in instructions) 
            {
                if (i.Inst == 'F')
                {
                    shipPos[0] += wayPointPos[0] * i.Amount; 
                    shipPos[1] += wayPointPos[1] * i.Amount; 
                }
                if (i.Inst == 'N') wayPointPos[1] += i.Amount; 
                if (i.Inst == 'E') wayPointPos[0] += i.Amount; 
                if (i.Inst == 'S') wayPointPos[1] -= i.Amount; 
                if (i.Inst == 'W') wayPointPos[0] -= i.Amount; 
                if (i.Inst == 'L') 
                {
                    var result = RotateWayPoint(wayPointPos[0], wayPointPos[1], i.Amount); 
                    wayPointPos[1] = result.Item2;   
                    wayPointPos[0] = result.Item1;  
                } 
                if (i.Inst == 'R') 
                {
                    var result = RotateWayPoint(wayPointPos[0], wayPointPos[1], -i.Amount); 
                    wayPointPos[1] = result.Item2;  
                    wayPointPos[0] = result.Item1; 
                }
            }
            System.Console.WriteLine("Final Location of the ship in PTII {0} + {1} = {2}",  shipPos[1], shipPos[0], Math.Abs(shipPos[1]) + Math.Abs(shipPos[0]));
        }

        public static (int, int) RotateWayPoint(int x, int y, int degrees) 
        {
            double r = Math.PI * degrees / 180; 
            double newX = x * Math.Cos(r) - y * Math.Sin(r); 
            double newY = y * Math.Cos(r) + x * Math.Sin(r);  
            return (Convert.ToInt32(newX), Convert.ToInt32(newY));
        }

        public static uint GetFacing(uint curFacing, int amt, char rotate) 
        {
            int r = amt/90;
            if (rotate == 'L') return (curFacing - (uint)r ) % 4; 
            return (curFacing + (uint)r ) % 4;
        }

        // Attempt to use only degrees but was more of a hassle
        public static int RotateLeft(int curFacing, int nxtFacing)
        {
            int nxtPos = curFacing + nxtFacing; 
            if (nxtPos > 360) 
                return nxtPos - 360; 
            return nxtPos; 
        }

        public static int RotateRight(int curFacing, int nxtFacing) 
        {
            int nxtPos = curFacing - (360 - nxtFacing); 
            return Math.Abs(nxtPos);
        }
    }
}
