using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSerializationAndDeserialization.Model
{
    [Serializable]
    internal class Movie
    {
        public string movieName { get; set; }
        public string genre { get; set; }
        public string director { get; set; }
        public int yearOfRelease { get; set; }

        public Movie() { }
        public Movie(string movieName, string genre, string director, int yearOfRelease)
        {
            this.movieName = movieName;
            this.genre = genre;
            this.director = director;
            this.yearOfRelease = yearOfRelease;
        }
    }
}
