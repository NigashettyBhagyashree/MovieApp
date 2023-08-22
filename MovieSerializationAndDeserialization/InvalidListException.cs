using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSerializationAndDeserialization
{
    internal class InvalidListException:Exception
    {
        public InvalidListException(string message):base(message) { }
    }
}
