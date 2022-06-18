#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P2206
{
    public class DbNummer
    {
        public ObjectId Id { get; set; }
        public string TObject { get; set; }

        public int Nummer { get; set; }
    }

    public class DbAdressen : INotifyPropertyChanged
    {

        // Die Id. 
        private ObjectId _id;
        private string _tellid;
        private int _version;
        private int _cmbTyp;
        private bool _deaktiv;
        private DateTime _anlage;
        private DateTime _geaendert;
        private string _editorname;
        private string _editornamel;
        private string _editornamer;
        private string _editoranschriftl;
        private string _editoranschriftr;
        private string _editorkontaktl;
        private string _editorkontaktr;
        private string _editorinternetl;
        private string _editorinternetr;
        private string _editorsonstigesl;
        private string _editorsonstigesr;
        private string _editorbem;

        public ObjectId Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        //.Text = "RolandKruggel824";
        public string TellId
        {
            get { return _tellid; }
            set
            {
                _tellid = value;
                OnPropertyChanged(nameof(TellId));
            }
        }
        // Die Version
        public int Version
        {
            get => _version;
            set
            {
                _version = value;
                OnPropertyChanged(nameof(Version));
            }
        }
        //.SelectedIndex = 0;
        public int CmbTyp
        {
            get => _cmbTyp;
            set
            {
                _cmbTyp = value;
                OnPropertyChanged(nameof(CmbTyp));
            }
        }

        // true, wenn der User ist deaktiviert
        public bool Deaktiv
        {
            get => _deaktiv;
            set
            {
                _deaktiv = value;
                OnPropertyChanged(nameof(Deaktiv));
            }
        }

        //.Text = DateTime.Now.ToString("g");
        public DateTime Anlage
        {
            get => _anlage;
            set
            {
                _anlage = value;
                OnPropertyChanged(nameof(Anlage));
            }
        }

        //.Text = DateTime.Now.ToString("g");
        public DateTime Geaendert
        {
            get => _geaendert;
            set
            {
                _geaendert = value;
                OnPropertyChanged(nameof(Geaendert));
            }
        }

        public string EditorNameL
        {
            get => _editornamel;
            set
            {
                _editornamel = value;
                OnPropertyChanged(nameof(EditorNameL));
            }
        }

        public string EditorNameR
        {
            get => _editornamer;
            set
            {
                _editornamer = value;
                OnPropertyChanged(nameof(EditorNameR));
            }
        }

        //.Text = "Straße:\tBeverst. 21\nOrt:\t58553 Halver\nLand:\tGermany";
        public string EditorAnschriftL
        {
            get => _editoranschriftl;
            set
            {
                _editoranschriftl = value;
                OnPropertyChanged(nameof(EditorAnschriftL));
            }
        }
        public string EditorAnschriftR
        {
            get => _editoranschriftr;
            set
            {
                _editoranschriftr = value;
                OnPropertyChanged(nameof(EditorAnschriftR));
            }
        }

        //.Text = "Tel:\t02353 6699940\nHandy:\t0174 2170044\nArbeit:\t02353 709-6271\neMail:\trkruggel@bbf7.de\neMail:\trkruggel@gmx.de\nwww\t\twww.bbf7.de\n";
        public string EditorKontaktL
        {
            get => _editorkontaktl;
            set
            {
                _editorkontaktl = value;
                OnPropertyChanged(nameof(EditorKontaktL));
            }
        }
        public string EditorKontaktR
        {
            get => _editorkontaktr;
            set
            {
                _editorkontaktr = value;
                OnPropertyChanged(nameof(EditorKontaktR));
            }
        }

        public string EditorInternetL
        {
            get => _editorinternetl;
            set
            {
                _editorinternetl = value;
                OnPropertyChanged(nameof(EditorInternetL));
            }
        }
        public string EditorInternetR
        {
            get => _editorinternetr;
            set
            {
                _editorinternetr = value;
                OnPropertyChanged(nameof(EditorInternetR));
            }
        }

        //.Text = "geschl.:\tmännlich\ngeb.:\t\t2.1.1959 (?alter?)";
        public string EditorSonstigesL
        {
            get => _editorsonstigesl;
            set
            {
                _editorsonstigesl = value;
                OnPropertyChanged(nameof(EditorSonstigesL));
            }
        }
        public string EditorSonstigesR
        {
            get => _editorsonstigesr;
            set
            {
                _editorsonstigesr = value;
                OnPropertyChanged(nameof(EditorSonstigesR));
            }
        }

        public string EditorBem
        {
            get => _editorbem;
            set
            {
                _editorbem = value;
                OnPropertyChanged(nameof(EditorBem));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

    internal class Db
    {
        public static int a;

        public static string filename()
        {
            FileInfo? fi = new FileInfo(Assembly.GetEntryAssembly().Location);
            var dbfile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"P2206.db");
            return dbfile;
        }

        public static int getNumber(string TObject)
        {
            int erg = 0;

            // Open database (or create if doesn't exist)
            using (var idb = new LiteDatabase(filename()))   //dbfile))
            {
                // Get customer collection
                var col = idb.GetCollection<DbNummer>("dbNummer");

                DbNummer? results = col.Find(x => x.TObject == TObject).FirstOrDefault();

                if (results is null)
                {
                    var dbNummer = new DbNummer
                    {
                        Id = new ObjectId(),
                        TObject = TObject,
                        Nummer = 10000
                    };

                    // Create unique index in Name field
                    col.EnsureIndex(x => x.TObject, true);

                    // Insert new customer document(Id will be auto - incremented)
                    col.Insert(dbNummer);

                    results = col.Find(x => x.TObject == TObject).FirstOrDefault();

                }

                var xid = results.Id;
                var xma = results.Id.Machine;
                double xda = results.Id.Timestamp;
                var xpi = results.Id.Pid;

                var xdd = results.Id.CreationTime.ToString("g");

                results.Nummer++;

                col.Update(results);
                erg = results.Nummer;

            }


            return erg;
        }

        public static int saveAdresse(DbAdressen dbAdressen)
        {
            using (var idb = new LiteDatabase(filename()))   
            {
                // Get customer collection
                //var col = idb.GetCollection<DbAdressen>("dbAdressen");
                var col = idb.GetCollection<DbAdressen>("dbAdressen");

                //DbNummer? results = col.Find(x => x.TObject == TObject).FirstOrDefault();

                //if (results is null)
                //{
                //    var dbNummer = new DbNummer
                //    {
                //        Id = new ObjectId(),
                //        TObject = TObject,
                //        Nummer = 10000
                //    };

                // Create unique index in Name field
                col.EnsureIndex(x => x.TellId, true);

                // Insert new customer document(Id will be auto - incremented)
                col.Insert(dbAdressen);

                dbAdressen.Id = new ObjectId();

                //var results = col.Find();  //x => x.dbAdressen == dbAdressen).FirstOrDefault();



                //}

                //var xid = results.Id;
                //var xma = results.Id.Machine;
                //double xda = results.Id.Timestamp;
                //var xpi = results.Id.Pid;

                //var xdd = results.Id.CreationTime.ToString("g");

                //results.Nummer++;

                //col.Update(results);
                //erg = results.Nummer;

            }

            return 0;
        }

        public static List<DbAdressen> getAllAdressen()
        {
            List<DbAdressen> dadr;  // = new DbAdressen();
            using (var idb = new LiteDatabase(filename()))
            {
                var resu = idb.GetCollection<DbAdressen>("dbAdressen");

                dadr = resu.FindAll().ToList();
            }

            var da1 = dadr[0].TellId;
            var da2 = dadr[1].TellId;
            var da3 = dadr[2].TellId;

            return dadr;
        }

    }
}
