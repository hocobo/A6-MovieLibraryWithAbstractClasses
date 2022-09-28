using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Transactions;

namespace A6___MovieLibraryWithAbstractClasses.AbstractClasses
{
    public class Movie : Media
    {
        public string[] Genres { get; set; }
        
        public List<int> MovieIds { get; set; }
        public List<string> MovieTitles{ get; set; }
        public List<string> MovieGenres{ get; set; }

        public Movie()
        {
            Read();
            Display();
        }


        public override void Read()
        {
            try
            {
                StreamReader sr = new StreamReader($"{Environment.CurrentDirectory}movies.csv");
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line != null)
                    {
                        int idx = line.IndexOf('"');
                        if (idx == -1)
                        {
                            string[] movieDetails = line.Split(',');
                            MovieIds.Add(int.Parse(movieDetails[0]));
                            MovieTitles.Add(movieDetails[1]);
                            MovieGenres.Add(movieDetails[2].Replace("|", ", "));
                        }
                        else
                        {
                            MovieIds.Add(int.Parse(line.Substring(0, idx - 1)));
                            line = line.Substring(idx + 1);
                            idx = line.IndexOf('"');
                            MovieTitles.Add(line.Substring(0, idx));
                            line = line.Substring(idx + 2);
                            MovieGenres.Add(line.Replace("|", ", "));
                        }
                    }
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("File not found");
            }
        }

        public override void Display()
        {
            for (int i = 0; i < MovieIds.Count; i++)
            {
                Console.WriteLine($"Id: {MovieIds[i]}");
                Console.WriteLine($"Title: {MovieTitles[i]}");
                Console.WriteLine($"Genre(s): {MovieGenres[i]}");
                Console.WriteLine();
            }
        }
    }
}