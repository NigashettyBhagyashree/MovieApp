using MovieSerializationAndDeserialization.Model;
using MovieSerializationAndDeserialization.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieSerializationAndDeserialization.Controller
{
    internal class MovieController
    {
        
        public MovieController()
        {
            Start();
        }

        private void Start()
        {
            DisplayMenu();
        }

        private void DisplayMenu()
        {
            while (true)
            {
                MovieManager.loadMovies();
                //Console.WriteLine("Movies count is :" + movies.Count + "/5");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1 = Add movies : \n" +
                    "2 = Display all movies\n" +
                    "3 = Display Movies by year\n" +
                    "4 = Remove movie by name\n" +
                    "5 = Remove all\n" +
                    "6 = Exit");
                Console.Write("Enter your choice :");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-------------------------------");
                if (choice == 1)
                    SetMovieDetails();
                else if (choice == 2)
                {
                    DisplayAll(MovieManager.GetMovies());
                }
                else if (choice == 3)
                {
                    DisplayByYear(MovieManager.GetMovieIndex());
                }
                else if (choice == 4)
                    MovieManager.ClearMoviesByName();
                else if (choice == 5)
                {
                    MovieManager.DeleteAllMovies();
                }
                else if (choice == 6)
                    Environment.Exit(0);
                else
                    Console.WriteLine("Invalid input !!");
            }
        }


        public static void DisplayByYear(int index)
        {
            List<Movie> movieObject = MovieManager.GetMovies();
            Console.WriteLine(movieObject[index]);

        }

        public static void  DisplayAll(List<Movie> movies)
        {
            if (movies.Count > 0)
            {
                foreach (Movie movieObject in movies)
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine(movieObject); 
                    Console.WriteLine($"Movie Name : {movieObject.movieName}\n" + $"Movie Director : {movieObject.director}\n"
                       + $"Movie Genre :{movieObject.genre}\n" +
                      $"Year Of Realse :{movieObject.yearOfRelease}");
                }
            }
            else
              Console.WriteLine("List is empty :");
        }

        private static Movie SetMovieDetails()
        {
            string Name;
            string genre;
            string director;
            int year;
            Console.Write("Enter Movie Name :");
            Name = Console.ReadLine();
            Console.Write("Enter Movie Genre :");
            genre = Console.ReadLine();
            Console.Write("Enter Movie Director Name :");
            director = Console.ReadLine();
            Console.Write("Enter Movie year of Release :");
            year = Convert.ToInt32(Console.ReadLine());
            Movie movieObject = new Movie(Name, genre, director, year);
            try
            {
                MovieManager.AddMovie(movieObject);


            }catch(InvalidListException ile)
            {
                Console.WriteLine(ile.Message);
            }

            return movieObject;
        }
    }
    
}
