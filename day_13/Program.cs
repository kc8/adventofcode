using System;
using System.Collections;
using System.Collections.Generic;
using System.IO; 

namespace day_13
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = new List<string>(); 
            string test_file = "test_input.txt"; 
            string file = "input.txt"; 
            //parse(test_file, ref data); 
            parse(file, ref data); 
            string[] parsedData = data[1].Split(","); 
            List<int> buses = new List<int>(); 
            int time = 0; 
            Int32.TryParse(data[0], out time); 
            foreach(string i in parsedData)
            {
                if (i != "x") 
                {
                    int bus = 0; 
                    Int32.TryParse(i, out bus);
                    buses.Add(bus); 
                }
            }
            partI(buses, time);    
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

        public static void partI(List<int> buses, int time) 
        {
            Dictionary<int, int> results = new Dictionary<int, int>(); 
            foreach (int i in buses) 
            {
                double amt = (double)time/i;
                //System.Console.WriteLine(amt); 
                double t = Math.Round(amt, 0, MidpointRounding.AwayFromZero); 
                double takes = t * i; 
                System.Console.WriteLine("Time for bus {0} is {1} at {2} ", i, Convert.ToInt32(takes), t); 
                System.Console.WriteLine("Time for bus {0}", (Convert.ToInt32(takes) - time)* i); 
                System.Console.WriteLine(); 
                results.Add(i, Convert.ToInt32(takes));
            }
        }
    }
}
