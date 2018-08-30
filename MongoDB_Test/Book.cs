using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB_Test
{
    public class Book
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("title")]  
        public string Title { get; set; }
        [BsonElement("price")]
        public double Price { get; set; }

        public Book(string title,double price)
        {
            Title = title;
            Price = price;
        }
    }
}
