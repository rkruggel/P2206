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
        //DbAdressen dbAdressen;

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


        #region Screen Adressen geladen

        private void grdMain_Loaded(object sender, RoutedEventArgs e)
        {
            //liteDbTest();       // aufruf des Test



            //var li = dbAdressen.EditorSonstigesR.Split('\n');
            //for (int i = 0; i < li.Length; i++)
            //{
            //    var item = li[i];
            //    var asu = "(?alter?)";
            //    if (item.Contains(asu)) {
            //        var ld = item.Split('\t', StringSplitOptions.RemoveEmptyEntries);
            //        var dat = ld[0].Replace(asu, "").Trim();
            //        var parseDate = DateTime.Parse(dat);

            //        int years = DateTime.Now.Year - parseDate.Year;
            //        parseDate = parseDate.AddYears(years);
            //        if (DateTime.Now.CompareTo(parseDate) < 0) { years--; }

            //        var newDat = $"{years} Jahre";
            //        item.Replace(asu, newDat);

            //        a = 0;
            //    }
            //}

            // abhängig von der Combobox 'Alle Daten' werden die Daten angezeigt
            ckBox_Click(null, null);

        }

        #endregion


        #region Button Del

        private void btnCmdDel_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion


        #region Button Edit

        private void btnCmdEdit_Click(object sender, RoutedEventArgs e)
        {
            var ajj = Db.getAllAdressen();
        }

        #endregion


        #region Button Add

        private void btnCmdAdd_Click(object sender, RoutedEventArgs e)
        {
            dbAdressen = new DbAdressen()
            {
                Id = new ObjectId(),                       //.Text = "878122";
                TellId = "",    //.Text = "RolandKruggel824";
                TellFlag = "y",
                Version = 0,                    //Die Version. Wird bei jedem ändern un eins erhöht; default = 0
                CmbTyp = 0,                     //.SelectedIndex = 0;
                Deaktiv = false,
                Anlage = DateTime.Now,          //.Text = DateTime.Now.ToString("g");
                Geaendert = DateTime.Now,       //.Text = DateTime.Now.ToString("g");           
                EditorNameL = "Anrede:\nTitel:\nName:\nZusatz:",    //.Text = "Anrede:\tHerr \nTitel:\tProf. Dr. vet. \nName:\tRoland Kruggel";
                EditorNameR = "",
                EditorAnschriftL = "Straße:\nOrt:\nLand:",       //.Text = "Straße:\tBeverst. 21\nOrt:\t58553 Halver\nLand:\tGermany";
                EditorAnschriftR = "",
                EditorKontaktL = "Tel:\nHandy:\nArbeit:\n",         //.Text = "Tel:\t02353 6699940\nHandy:\t0174 2170044\nArbeit:\t02353 709-6271\neMail:\trkruggel@bbf7.de\neMail:\trkruggel@gmx.de\nwww\t\twww.bbf7.de\n";
                EditorKontaktR = "",
                EditorInternetL = "eMail:\nwww:",
                EditorInternetR = "",
                EditorSonstigesL = "geschl.:\ngeb.:",        //.Text = "geschl.:\tmännlich\ngeb.:\t\t2.1.1959 (?alter?)";
                EditorSonstigesR = "",
                EditorBem = "--"
            };


            var ahh = dbAdressen.CmbTyp;

            this.DataContext = null;
            this.DataContext = dbAdressen;

            ckBox_Click(null, null);
        }

        #endregion


        #region Button Ok
        private void btnCmdOk_Click(object sender, RoutedEventArgs e)
        {
            Db.saveAdresse(dbAdressen);
        }

        #endregion


        #region ListView

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

        /// <summary>
        /// Event
        /// Wenn ein Eintrag in der ListView geklickt wird.
        /// Um zu selectieren muss zwei mal geklickt werden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #endregion


        #region txtName 

        /// <summary>
        /// Event
        /// Wird ausgelöst wenn in txtNameR eine Taste gedrückt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNameR_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var tx = sender as TextBox;

            if (e.Key == Key.Enter || e.Key == Key.Down || e.Key == Key.Up)
            {
                DbAdressen? vm = DataContext as DbAdressen;
                if(vm.TellId.Trim().Length == 0)
                    vm.TellId = createTellId();
            }
            a = 0;
        }

        /// <summary>
        /// Erzeugt eine neue TellId
        /// Die TellId darf nicht geändert werden. Sie ist die Haupt-Such-ID
        /// </summary>
        /// <returns></returns>
        private string createTellId()
        {
            var newText = "";

            // Die linke und rechte Textbox als Liste 
            List<string> textboxL = ((TextBox)FindName($"txtNameL")).Text.Split('\n').ToList();
            List<string> textboxR = ((TextBox)FindName($"txtNameR")).Text.Split('\n').ToList();

            // Der Index von Vorname und Name
            var indexV = textboxL.FindIndex(x => x.StartsWith("Vorn"));
            var indexN = textboxL.FindIndex(x => x.StartsWith("Name"));

            try
            {
                if (indexV != -1)
                {
                    newText = textboxR[indexV];
                }

                if (indexN != -1)
                {
                    newText += textboxR[indexN];
                }

                newText = newText.Replace(" ", "").Replace("\t", "").Replace("\n", "");

                if (newText.Length == 0)
                    return "";

                newText += new Random().Next(100, 999).ToString();
            }
            catch (Exception)
            {
                return "";
            }

            return newText;
        }

        #endregion

    }
}
