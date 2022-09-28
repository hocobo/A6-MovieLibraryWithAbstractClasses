using System;
using System.Collections.Generic;
using System.IO;

namespace A6___MovieLibraryWithAbstractClasses.AbstractClasses
{
    public class Show : Media
    {
        public List<int> ShowIds { get; set; }
        public List<string> ShowTitles { get; set; }    
        public List<string> ShowEpisode { get; set; }
        public List<string> ShowSeason { get; set; }    
        public List<string> ShowWriters { get; set; }   

        public int Episode { get; set; }
        public int Season { get; set; } 
        public string Writers { get; set; }

        public Show()
        {
            Read();
            Display();
        }
        public override void Read()
        {
            try
            {
                StreamReader sr = new StreamReader($"{Environment.CurrentDirectory}shows.csv");
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line != null)
                    {
                        int idx = line.IndexOf('"');
                        string[] showDetails = line.Split(',');
                        ShowIds.Add(int.Parse(showDetails[0]));
                        ShowTitles.Add(showDetails[1]);
                        ShowEpisode.Add(showDetails[2]);
                        ShowSeason.Add(showDetails[3]);
                        ShowWriters.Add(showDetails[4]);
                    }
                }
                sr.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found");
            }
        }
        
        public override void Display()
        {
            for (int i = 0; i < ShowIds.Count; i++)
            {
                Console.WriteLine($"Id: {ShowIds[i]}");
                Console.WriteLine($"Title: {ShowTitles[i]}");
                Console.WriteLine($"Video Format: {ShowEpisode[i]}");
                Console.WriteLine($"Video Length: {ShowSeason[i]}");
                Console.WriteLine($"Video Region: {ShowWriters[i]}");
                Console.WriteLine();
            }
        }
    }
}