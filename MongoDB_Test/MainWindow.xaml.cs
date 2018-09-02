
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB_Test.Models.EF;
using MongoDB_Test.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MongoDB_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MongoClient client = new MongoClient();
        private static IMongoDatabase db = client.GetDatabase("TestWPFDB");
        private static IMongoCollection<Book> collection = db.GetCollection<Book>("books");
        private TerminRepositoriyEF terminRepositoryEF;

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
            DatabaseEF.MessageTime += DatabaseEF_MessageTime;
            Database.MessageTime += Database_MessageTime;
            terminRepositoryEF = new TerminRepositoriyEF();
        }

        private void Database_MessageTime(long obj)
        {
            tbETime.Text = obj.ToString();
        }

        private void DatabaseEF_MessageTime(long obj)
        {
            tbETime.Text = obj.ToString();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var r = new BookRepository();
            ////r.adddBook("test", 12, "Methusalem", 921);
            ////r.adddBook("Bibel", 26.80, "Diverse", 0);



            //r.adddBook(new Book("Neues Kompendium",112.19), 
            //    new List<Author> { new Author ( "Rosenstein", 89 )
            //    ,new Author("Earl Grey",47)
            //    , new Author("HenningStreet",74)
            //    ,new Author("Green, Marquess of",51)
            //    }  );

            //r.adddBook(new Book("Scheitern als Weg", 112.19),
            // new List<Author> { new Author ( "War nix", 89 )
            //    ,new Author("Boah Eeeh",47)
            //    , new Author("Altah Faltah",74)
            //    ,new Author("Schnurz Pieep-Egal",51)
            // });

            var t = new Repositories.TerminRepositoriy();
            // t.addTermine(Database.GetTermine());
            // LBTermine.ItemsSource = t.GetAllTermine();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoadMongo_Click(object sender, RoutedEventArgs e)
        {
            var t = new Repositories.TerminRepositoriy();
            // t.addTermine(Database.GetTermine());
            //LBTermine.ItemsSource = t.GetAllTermine();

            List<MongoDB_Test.Models.Termin> TermineMo = t.GetAllTermine();
            // dgBook.ItemsSource = TermineMo;

            //IEnumerable<MongoDB_Test.Models.Termin> Test= TermineMo.Where(l => l.Datum.CompareTo(new DateTime(2018, 9, 1, 0, 0, 0)) == 0);
            //LBTermineMo.ItemsSource = TermineMo;
            LBTermineMo.ItemsSource = TermineMo.Where(l => l.Datum.CompareTo(new DateTime(2018, 9, 1, 0, 0, 0)) > 0 && l.Datum.CompareTo(new DateTime(2018, 9, 2, 0, 0, 0)) < 0).OrderBy(o => o.Uhrzeit);

            LBTermineDi.ItemsSource = TermineMo.Where(l => l.Datum.CompareTo(new DateTime(2018, 9, 2, 0, 0, 0)) > 0 && l.Datum.CompareTo(new DateTime(2018, 9, 3, 0, 0, 0)) < 0).OrderBy(o => o.Uhrzeit);
            LBTermineMi.ItemsSource = TermineMo.Where(l => l.Datum.CompareTo(new DateTime(2018, 9, 3, 0, 0, 0)) > 0 && l.Datum.CompareTo(new DateTime(2018, 9, 4, 0, 0, 0)) < 0).OrderBy(o => o.Uhrzeit);
            LBTermineDo.ItemsSource = TermineMo.Where(l => l.Datum.CompareTo(new DateTime(2018, 9, 4, 0, 0, 0)) > 0 && l.Datum.CompareTo(new DateTime(2018, 9, 5, 0, 0, 0)) < 0).OrderBy(o => o.Uhrzeit);
            LBTermineFr.ItemsSource = TermineMo.Where(l => l.Datum.CompareTo(new DateTime(2018, 9, 5, 0, 0, 0)) > 0 && l.Datum.CompareTo(new DateTime(2018, 9, 6, 0, 0, 0)) < 0).OrderBy(o => o.Uhrzeit);
        }

        private void btnCreateMongo_Click(object sender, RoutedEventArgs e)
        {
            var t = new Repositories.TerminRepositoriy();
            t.addTermine(Database.GetTermine());
            //LBTermine.ItemsSource = t.GetAllTermine();
        }

        private void btnLoadEF_Click(object sender, RoutedEventArgs e)
        {
            //var t = new Repositories.TerminRepositoriyEF();
            // t.addTermine(Database.GetTermine());
            // LBTermine.ItemsSource = t.GetAllTermine();

            List<Termin> TermineEF = terminRepositoryEF.GetAllTermine();

            LBTermineMo.ItemsSource = TermineEF.Where(l => l.Datum.CompareTo(new DateTime(2018, 9, 1, 0, 0, 0)) == 0).OrderBy(o => o.Uhrzeit);
            LBTermineDi.ItemsSource = TermineEF.Where(l => l.Datum.CompareTo(new DateTime(2018, 9, 2, 0, 0, 0)) == 0).OrderBy(o => o.Uhrzeit);
            LBTermineMi.ItemsSource = TermineEF.Where(l => l.Datum.CompareTo(new DateTime(2018, 9, 3, 0, 0, 0)) == 0).OrderBy(o => o.Uhrzeit);
            LBTermineDo.ItemsSource = TermineEF.Where(l => l.Datum.CompareTo(new DateTime(2018, 9, 4, 0, 0, 0)) == 0).OrderBy(o => o.Uhrzeit);
            LBTermineFr.ItemsSource = TermineEF.Where(l => l.Datum.CompareTo(new DateTime(2018, 9, 5, 0, 0, 0)) == 0).OrderBy(o => o.Uhrzeit);


        }

        private void btnCreateEF_Click(object sender, RoutedEventArgs e)
        {

            // var t = new Repositories.TerminRepositoriyEF();
            terminRepositoryEF.addTermine(DatabaseEF.GetTermine());
            terminRepositoryEF.SaveChanges();
            //LBTermine.ItemsSource = t.GetAllTermine();
        }

        private void btnClearGrid_Click(object sender, RoutedEventArgs e)
        {
            LBTermineMo.ItemsSource = null;
            LBTermineDi.ItemsSource = null;
            LBTermineMi.ItemsSource = null;
            LBTermineDo.ItemsSource = null;
            LBTermineFr.ItemsSource = null;
        }

        private void btnClearDBs_Click(object sender, RoutedEventArgs e)
        {
            var r_ef = new TerminRepositoriyEF();
            r_ef.ClearTermine();

            var r_mo = new TerminRepositoriy();
            r_mo.ClearTermine();

        }

        private void LBTermineDi_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Termin t = (Termin)LBTermineDi.SelectedItem;
            if (t != null)
            {
                BehandlerPatientenTermin bpt = t.BehandlerPatientenTermine.Where(n => n.BehandlerID == 1).SingleOrDefault();
                bpt.PatientenName = "Arpad Stoever";
                bpt.PatientenID = 99;
                terminRepositoryEF.SaveChanges();

            }

        }

        private void SetRessource()
        {

            //var templ = (DataTemplate)this.FindResource("TerminTemplate");
            //WeekdayListBox.ItemTemplate = templ;

        }

        private void lbBehandler_MouseUp(object sender, MouseButtonEventArgs e)
        {

            //var x = (System.Windows.Controls.ListBox)sender;
            //BehandlerPatientenTermin bpt =(BehandlerPatientenTermin) x.SelectedItem;

            //if (bpt != null)
            //{
            //    //x.Background =  Brushes.Yellow;
            //    bpt.PatientenName = "Arpad Stoever";
            //    bpt.PatientenID = 99;
            //    terminRepositoryEF.SaveChanges();

            //}
        }

        private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var x = (System.Windows.Controls.TextBlock)sender;
            if (e.ChangedButton== MouseButton.Left)
            {
               
                x.Text = "Arpad Stoever";
                x.Background = Brushes.Yellow;
            }
            else if (e.ChangedButton== MouseButton.Right)
            {
                x.Text = "Nicht belegt";
                x.Background = Brushes.White;
            }
            else if (e.ChangedButton==MouseButton.Middle)
            {
                MessageBox.Show("Detailbearbeitung wird geöffnet");
            }
            else
            {
                MessageBox.Show("Uuuups . . . . ");
            }

        }
    }
}
