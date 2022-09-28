using System;
using System.Collections.Generic;
using System.IO;

namespace A6___MovieLibraryWithAbstractClasses.AbstractClasses
{
    public class Video : Media
    {
        public string Format { get; set; }  
        public int Length { get; set; } 
        public int[] Regions { get; set; }
        
        public List<int> VideoIds { get; set; } 
        public List<string> VideoTitles { get; set; }   
        public List<string> VideoFormat { get; set; }   
        public List<int> VideoLength { get; set; }  
        public List<string> VideoRegions { get; set; }

        public Video()
        {
            Read();
            Display();
        }

        public override void Read()
        {
            try
            {
                StreamReader sr = new StreamReader($"{Environment.CurrentDirectory}videos.csv");
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line != null)
                    {
                        int idx = line.IndexOf('"');
                        string[] videoDetails = line.Split(',');
                        VideoIds.Add(int.Parse(videoDetails[0]));
                        VideoTitles.Add(videoDetails[1]);
                        VideoFormat.Add(videoDetails[2]);
                        VideoLength.Add(int.Parse(videoDetails[3]));
                        VideoRegions.Add(videoDetails[4]);
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
            for (int i = 0; i < VideoIds.Count; i++)
            {
                Console.WriteLine($"Id: {VideoIds[i]}");
                Console.WriteLine($"Title: {VideoTitles[i]}");
                Console.WriteLine($"Video Format: {VideoFormat[i]}");
                Console.WriteLine($"Video Length: {VideoLength[i]}");
                Console.WriteLine($"Video Region: {VideoRegions[i]}");
                Console.WriteLine();
            }
        }
    }
}