using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB_Test
{
    public class BookRepository
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("BookTestDB");
        static IMongoCollection<Book> collection = db.GetCollection<Book>("Books");

        public void adddBook(string title, double price)
        {
            Book b = new Book(title, price);
            collection.InsertOne(b);
           
        }
        public void adddBook(Book b)
        {
           
            collection.InsertOne(b);

        }

        public void adddBook(Book b, Author a)
        {
            b.addAuthor(a);
            collection.InsertOne(b);

        }

        public void adddBook(Book b,List<Author> authors)
        {

            b.addAuthorList(authors);
            collection.InsertOne(b);

        }

        public void adddBook(string title, double price,string name,int age)
        {
            Book b = new Book(title, price);
            Author a = new Author(name, age);
            b.addAuthor(a);
            collection.InsertOne(b);

        }

     





        public void ReadAllDocuments()
        {
            //List<Book> list = collection.AsQueryable().ToList<Book>();
            //dgBook.ItemsSource = list;
            //Book b = (Book)dgBook.Items.GetItemAt(0);
            //tbId.Text = b.Id.ToString();
            //tbTitle.Text = b.Title;
            //tbPrice.Text = b.Price.ToString();

        }
    }
}
