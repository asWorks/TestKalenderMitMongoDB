
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MongoDB_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("TestWPFDB");
        static IMongoCollection<Book> collection = db.GetCollection<Book>("books");

        public void ReadAllDocuments()
        {
            List<Book> list = collection.AsQueryable().ToList<Book>();
            dgBook.ItemsSource = list;
            Book b = (Book)dgBook.Items.GetItemAt(0);
            tbId.Text = b.Id.ToString();
            tbTitle.Text = b.Title;
            tbPrice.Text = b.Price.ToString();

        }
        public MainWindow()
        {
            InitializeComponent();
            ReadAllDocuments();
        }

        private void dgBook_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Book b = (Book)dgBook.SelectedItem;
            if (b != null)
            {
                tbId.Text = b.Id.ToString();
                tbTitle.Text = b.Title;
                tbPrice.Text = b.Price.ToString();
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Book b = new Book(tbTitle.Text, Double.Parse(tbPrice.Text));
            collection.InsertOne(b);
            ReadAllDocuments();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var updateDef = Builders<Book>.Update.Set("title", tbTitle.Text)
                .Set("price", tbPrice.Text);
            collection.UpdateOne(b => b.Id == ObjectId.Parse(tbId.Text), updateDef);
            ReadAllDocuments();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            collection.DeleteOne(b => b.Id == ObjectId.Parse(tbId.Text));
            ReadAllDocuments();
        }
    }
}
