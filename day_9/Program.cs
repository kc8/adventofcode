using System;
using System.Collections; 
using System.Collections.Generic;
using System.IO; 
using System.Linq;

namespace day_9
{
    class Program
    {
        static void Main(string[] args)
        {

            var data = new List<string>(); 
            var numbers = new List<int>();
            string file = "./test_input.txt";
            int valIndex = 4; 
           // string file = "./input.txt";
           // int valIndex = 24; 
            parse(file, ref data);
            foreach(var i in data)
            {
                int num = 0; 
                Int32.TryParse(i, out num);
                numbers.Add(num);
            }
            //part I: Find the Inavlaid numbers
            List<int> currentNumbers = new List<int>(); 
            int count = 0; 
            int index = 0; 
            int invalidNum = 0; 
            foreach (var i in numbers)
            {
                if (index > valIndex) 
                {
                    bool found = FindInvalidPartI(i, ref currentNumbers);
                    if (!found) 
                    {
                        System.Console.WriteLine("NO NUMBER FOUND FOR: {0}", i);
                        invalidNum = i; 
                        break; 
                    }
                    if (found) 
                    {
                        currentNumbers.RemoveAt(0); 
                        currentNumbers.Add(i); 
                        count = 0; 
                    }
                }
                else {
                    count += 1;  
                    currentNumbers.Add(i);
                }
                index++; 
            }
            List<int> rangeOfPartIINums = PartII(invalidNum, ref numbers); 

            if (rangeOfPartIINums.Count > 0) 
            {
                int lgsm = rangeOfPartIINums.Min() + rangeOfPartIINums.Max();
                System.Console.WriteLine("LARGEST + SMALLEST = {0}", lgsm);
            }
        }
        
        public static List<int> PartII(int sumTo, ref List<int> numbers) 
        {
            //This method is not currently working 
            List<int> contiRange = new List<int>(); 
            int currentContiRangeSum = 0; 
            int index = 0; 
            int tot = 0; 
            
            //System.Console.WriteLine("index {0}", numbers[0]);

            foreach(int i in numbers) 
            {
                currentContiRangeSum += i; 
                tot = sumTo - currentContiRangeSum;
                System.Console.WriteLine(tot); 
                if (tot == 0) 
                {
                    System.Console.WriteLine("FOUND LIST OF INTS");
                    contiRange.Add(i);
                    return contiRange;
                }
                if (tot > i || tot < 0) 
                {
         //           System.Console.WriteLine(contiRange[0]); 
        //         currentContiRangeSum -= contiRange[0];
                    contiRange.Remove(0);
                }
                contiRange.Add(i); 
            }
            System.Console.WriteLine("FAILED TO FIND INTS");
            return new List<int>(); 
        }

        public static bool FindInvalidPartI(int sumTo, ref List<int> numbers) 
        {
        //IDEA: We could use a hash set to keep track of numbers, Two Sum problem
            int tot = 0; 
            foreach(int i in numbers) 
            {
                if (i > sumTo)
                {
                    continue;  
                }
                foreach(int s in numbers)
                {
                    tot = i + s;
                    //System.Console.WriteLine("here {0} + {1} = {2}", i, s, tot);
                    if (s == i) continue; 
                    if ( s +  i == sumTo) return true; 
                }
            }
            return false;  
        }

        public static void parse(string file, ref List<string> data) 
        {
            if(data == null) return; 
            if(file == null) return; 
            string[] lines = File.ReadAllLines(file);
            foreach(var s in lines) 
            {
                data.Add(s);
            }
        }
        
    }
}
