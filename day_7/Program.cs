using System;
using System.Collections; 
using System.Collections.Generic;
using System.IO;

namespace day_7
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<string>(); 
            var AllBags = new List<Bags>();
            string parseFile = "./test_input.txt";
            foreach(string i in data) { System.Console.WriteLine(i); }
            ReadInput(parseFile, ref data); 
            CleanInput(ref data, ref AllBags);
        }

        public static void ReadInput(string file, ref List<string> data)
        {
            // Docs: https://docs.microsoft.com/en-us/dotnet/api/system.string.substring?view=net-5.0
            if (data == null) return; //Do I need this for ref?
            string uselessArray  = File.ReadAllText(file); 
            uselessArray.Replace("bags", "bag");
            uselessArray.Replace(".", "");
            uselessArray.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
            foreach(var in uselessArray) 
            {
            
            }
            data.Add(uselessArray);
        }
        
        public static void CleanInput(ref List<string> data, ref List<Bags> AllBags)
        {
            string[] splitOn = new String[] {",", "bags contain"};
            // I need to find a better way to do this next time .... 
        }
    }


    public class Bags 
    {
        public Dictionary<int, string> ContainingBags {get; set;}
        public string Name {get; set;}
        public bool NoBagsWithin {get; set;}

        public Bags() 
        {
            this.ContainingBags = new Dictionary<int, string>();
        }
    }
}
