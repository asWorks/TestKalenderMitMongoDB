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
        [BsonElement("authorlist")]
        public List<Author> Authorlist { get; set; }


        public Book(string title,double price)
        {
            Title = title;
            Price = price;
        }

        public void addAuthor(Author author)
        {
            if (Authorlist == null)
            {
                Authorlist = new List<Author>();
            }

            Authorlist
                .Add(author);
        }

        public void addAuthor(string name, int age)
        {

            Author a = new Author(name, age);
            addAuthor(a);
           
           
        }


        public void addAuthorList(List<Author> authors)
        {
            foreach (var item in authors)
            {
                addAuthor(item);
            }
        }
    }
}
