using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Transactions;

namespace A6___MovieLibraryWithAbstractClasses.AbstractClasses
{
    public class Movie : Media
    {
        private readonly List<Movie> movies = new List<Movie>();

        private int _MovieId { get; set; }
        private string _MovieTitle { get; set; } 
        private string _MovieGenre { get; set;} 

        public Movie(){}
        private Movie(int movieId, string movieTitle, string movieGenre)
        {
            _MovieId = movieId;
            _MovieTitle = movieTitle;
            _MovieGenre = movieGenre;
        }


        public override void Read()
        {
            try
            {
                StreamReader sr = new StreamReader(@"csvFolder\movies.csv");
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
                            _MovieId = (int.Parse(movieDetails[0]));
                            _MovieTitle = (movieDetails[1]);
                            _MovieGenre = (movieDetails[2].Replace("|", ", "));
                            movies.Add(new Movie(_MovieId,_MovieTitle,_MovieGenre));
                        }
                        else
                        {
                            _MovieId = (int.Parse(line.Substring(0, idx - 1)));
                            line = line.Substring(idx + 1);
                            idx = line.IndexOf('"');
                            _MovieTitle = (line.Substring(0, idx));
                            line = line.Substring(idx + 2);
                            _MovieGenre = (line.Replace("|", ", "));
                            movies.Add(new Movie(_MovieId,_MovieTitle,_MovieGenre));
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
            foreach (var movie in movies)
            {
                Console.WriteLine($"Id: {movie._MovieId}");
                Console.WriteLine($"Title: {movie._MovieTitle}");
                Console.WriteLine($"Genre(s): {movie._MovieGenre}");
                Console.WriteLine(); 
            }
        }
    }
}