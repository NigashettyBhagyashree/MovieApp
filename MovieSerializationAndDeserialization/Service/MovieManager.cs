using MovieSerializationAndDeserialization.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MovieSerializationAndDeserialization.Service
{
    internal class MovieManager
    {
        public static readonly string filepath = ConfigurationManager.AppSettings["path"];
        public const int length=5;
        private static List<Movie> movies;
        
        public MovieManager()
        {
            movies= new List<Movie>();
            loadMovies();
        }

        public static void loadMovies()
        {
            DataSerializer.BinaryDeserialize(filepath);
        }
        public static void saveMovies()
        {
            DataSerializer.BinarySerialize(movies,filepath);
        }
        public static void AddMovie(Movie movie)
        {
            if (movies.Count <= length)
            {
                movies.Add(movie);
                saveMovies();
            }
            else
            {
                throw new InvalidListException("List is full");
            }
        }
        //public static void RemoveMovieByName(Movie movie) 
        //{
        //    Movie movieToRemove = movies.Find(movie ==> movies == movie);
        //}
        public static void ClearAllMovies()
        {
            movies.Clear();
            saveMovies();
            Console.WriteLine("All movies removed from list");
        }
        public static int GetMovieIndex()
        {
            Console.WriteLine("================");
            Console.WriteLine("Enter movie year");
            int movieYear = Convert.ToInt32(Console.ReadLine());
            int index = 0;
            for(int i = 0;i<movies.Count;i++)
            {
                if (movies[i].yearOfRelease == movieYear) 
                    index = i;
            }
            return index;
        }
        public static List<Movie>GetMovies()
        {
            //if (movies.Count > 0)
            //{
            //    loadMovies();
            //    return movies;
            //}
            //else
            //{
            //    throw new ListEmptyException("List is empty");
            //}
            loadMovies();
            return movies;
        }
        public static void ClearMoviesByName()
        {
            Console.WriteLine("===============");
            Console.WriteLine("Enter movie name");
            string findMovie=Console.ReadLine();
            for(int i=0;i<movies.Count; i++)
            {
                if (movies[i].movieName == findMovie)
                {
                    movies.RemoveAt(i);
                }
            }
            saveMovies();
            Console.WriteLine("Movies deleted successfully");
        }
        public static void DeleteAllMovies()
        {
            movies.Clear();
            saveMovies() ;
            Console.WriteLine("All movies removed from list!!");
        }
        

    }
}
