#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
using System;
using System.Collections.Generic;
using System.IO;
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

using System.Reflection;
using LiteDB;
using P2206.db;
using P2206.db.beans;

namespace P2206
{
    /// <summary>
    /// Interaktionslogik für Adressen.xaml
    /// </summary>
    public partial class Adressen : Page
    {
        private int a;


        DbAdressen dbAdressen = new()
        {
            Id = new ObjectId(),                       //.Text = "878122";
            TellId = "RolandKruggel" + new Random().Next(100, 999).ToString(),    //.Text = "RolandKruggel824";
            TellFlag = "y",
            Version = 0,                    //Die Version. Wird bei jedem ändern un eins erhöht; default = 0
            CmbTyp = 0,                     //.SelectedIndex = 0;
            Deaktiv = false,
            Anlage = DateTime.Now,          //.Text = DateTime.Now.ToString("g");
            Geaendert = DateTime.Now,       //.Text = DateTime.Now.ToString("g");           
            EditorNameL = "Anrede:\nTitel:\nName:\nZusatz:",    //.Text = "Anrede:\tHerr \nTitel:\tProf. Dr. vet. \nName:\tRoland Kruggel";
            EditorNameR = "Herr \nProf. Dr. vet. \nRoland Kruggel\nHundetrainer",
            EditorAnschriftL = "Straße:\nOrt:\nLand:",       //.Text = "Straße:\tBeverst. 21\nOrt:\t58553 Halver\nLand:\tGermany";
            EditorAnschriftR = "Beverst. 21\n58553 Halver\nGermany",
            EditorKontaktL = "Tel:\nHandy:\nArbeit:\n",         //.Text = "Tel:\t02353 6699940\nHandy:\t0174 2170044\nArbeit:\t02353 709-6271\neMail:\trkruggel@bbf7.de\neMail:\trkruggel@gmx.de\nwww\t\twww.bbf7.de\n";
            EditorKontaktR = "02353 6699940\n0174 2170044\n02353 709-6271\n",
            EditorInternetL = "eMail:\neMail:\nwww:",
            EditorInternetR = "rkruggel@bbf7.de\nrkruggel@gmx.de\nwww.bbf7.de\n",
            EditorSonstigesL = "geschl.:\ngeb.:",        //.Text = "geschl.:\tmännlich\ngeb.:\t\t2.1.1959 (?alter?)";
            EditorSonstigesR = "männlich\n2.1.1959 (?alter?)",
            EditorBem = "Ein Text\nIm Editor Bem"
        };



        public Adressen()
        {
            InitializeComponent();
            this.DataContext = dbAdressen;
        }

        #region  Litedb Text -------------------------------------------------

        // Create your POCO class
        public class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string[] Phones { get; set; }
            public bool IsActive { get; set; }
            public DateTime DTime { get; set; }
        }


        private void liteDbTest()
        {
            int atr1 = Db.getNumber("adr");  //new Db().getNumber("adr");

            a = 0;

            //FileInfo fi = new FileInfo(Assembly.GetEntryAssembly().Location);
            //var dbfile = System.IO.Path.Combine( Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"P2206.db");

            //// Open database (or create if doesn't exist)
            //using (var db = new LiteDatabase(dbfile))
            //{
            //    // Get customer collection
            //    var col = db.GetCollection<Customer>("customers");

            //    // Create your new customer instance
            //    var customer = new Customer
            //    {
            //        Name = "John Doe1",
            //        Phones = new string[] { "8000-0000", "9000-0000" },
            //        Age = 39,
            //        IsActive = true,
            //        DTime = DateTime.Now
            //    };

            //    // Create unique index in Name field
            //    col.EnsureIndex(x => x.Name, true);

            //    // Insert new customer document (Id will be auto-incremented)
            //    col.Insert(customer);

            //    // Update a document inside a collection
            //    customer.Name = "Joana Doe1";

            //    col.Update(customer);

            //    // Use LINQ to query documents (with no index)
            //    var results = col.Find(x => x.Age > 20);
            //}

            a = 0;
        }

        #endregion Litedb Text ----------------------------------------------------


        private void grdMain_Loaded(object sender, RoutedEventArgs e)
        {
            //liteDbTest();       // aufruf des Test



            var li = dbAdressen.EditorSonstigesR.Split('\n');
            for (int i = 0; i < li.Length; i++)
            {
                var item = li[i];
                var asu = "(?alter?)";
                if (item.Contains(asu)) {
                    var ld = item.Split('\t', StringSplitOptions.RemoveEmptyEntries);
                    var dat = ld[0].Replace(asu, "").Trim();
                    var parseDate = DateTime.Parse(dat);

                    int years = DateTime.Now.Year - parseDate.Year;
                    parseDate = parseDate.AddYears(years);
                    if (DateTime.Now.CompareTo(parseDate) < 0) { years--; }

                    var newDat = $"{years} Jahre";
                    item.Replace(asu, newDat);

                    a = 0;
                }
            }

            // abhängig von der Combobox 'Alle Daten' werden die Daten angezeigt
            ckBox_Click(null, null);

            //lvDataBinding.ItemsSource = sjj;
        }

        private void btnCmdDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCmdEdit_Click(object sender, RoutedEventArgs e)
        {
            var ajj = Db.getAllAdressen();
        }

        private void btnCmdAdd_Click(object sender, RoutedEventArgs e)
        {
            dbAdressen.Id = new ObjectId();
            dbAdressen.Version = 3;
            dbAdressen.Deaktiv = true;
            dbAdressen.Anlage = DateTime.Now;
            dbAdressen.Geaendert = DateTime.Now;

            var ahh = dbAdressen.CmbTyp;
            
        }

        private void btnCmdOk_Click(object sender, RoutedEventArgs e)
        {
            Db.saveAdresse(dbAdressen);
        }

        /// <summary>
        /// Event
        /// Wird ausgelöst wenn in dem ListViewein Eintrag zwei mal geklickt wurde.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                var ajsjj = item.DataContext as DbAdressen;
                var tllid = ajsjj.TellId;
                a = 0;
           }
        }


        private void ckBox_Click(object sender, RoutedEventArgs e)
        {
            List<DbAdressen> listOfDbadr;

            // benötigt wird: Id, TellId, TellFlag, Version
            if (ckBox.IsChecked == true)
            {
                listOfDbadr = Db.getAllAdressen();
            }
            else
            {
                listOfDbadr = Db.getAllAdressenWithTellFlag();
            }
            lvDataBinding.ItemsSource = listOfDbadr;
        }
    }
}
