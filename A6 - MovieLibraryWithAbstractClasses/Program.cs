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
            Media media = null;

            switch (input)
            {
                case 1:
                    media = new Movie();
                    break;
                case 2:
                    media = new Show();
                    break;
                case 3:
                    media = new Video();
                    break;
            }
            media?.Display();
        }
    }
}