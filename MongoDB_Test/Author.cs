using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDB_Test
{
   public class Author
    {
        [BsonId]
        public Guid Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("age")]
        public int Age { get; set; }

        public Author(string name , int age)
        {
            Id = Guid.NewGuid();
            Age  = age;
            Name = name;
        }

    }
}
