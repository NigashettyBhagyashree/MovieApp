using MovieSerializationAndDeserialization.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MovieSerializationAndDeserialization.Service
{
    internal class DataSerializer
    {
        public static void BinarySerialize(List<Movie> data, string filepath)//data--football, Object--object of class person
        {
            using (FileStream file = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter(); 
                if (data.Count > 0)
                {
                    foreach (Movie mov in data)
                    {
                        formatter.Serialize(file, mov);
                    }
                }
                else
                {
                    formatter.Serialize(file,string.Empty);
                }
            }
                
        }
        public static List<Movie> BinaryDeserialize(string filepath)
        {
            List<Movie> movies = new List<Movie>();

            using (FileStream file = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                BinaryFormatter binary = new BinaryFormatter();
                while (file.Position < file.Length)
                {
                    movies.Add((Movie)binary.Deserialize(file));
                }
            }
            return movies;
        }

       
    }
}
