using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using A6___MovieLibraryWithAbstractClasses.AbstractClasses;

namespace A6___MovieLibraryWithAbstractClasses
{
    class Program
    {
        public static void Main(string[] args)
        {
            Menu();
            Switch();
        }

        public static void Menu()
        {
            Console.WriteLine("Select media type:\n1. Movie\n2. Show\n3. Video");
        }

        public static void Switch()
        {
            int input = Convert.ToInt32(Console.ReadLine());

            while (input == 1 || input == 2 || input == 3)
            {
                switch (input)
                {
                    case 1:
                        Media movie = new Movie();
                        movie.Read();
                        movie.Display();
                        break;
                    case 2:
                        Media show = new Show();
                        show.Read();
                        show.Display();
                        break;
                    case 3:
                        Media video = new Video();
                        video.Read();
                        video.Display();
                        break;
                }
                Console.WriteLine();
                input = Convert.ToInt32(Console.ReadLine());
            }
                
        }
    }
}