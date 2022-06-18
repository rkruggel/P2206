#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
using LiteDB;
using System;
using System.ComponentModel;

namespace P2206.db.beans
{
    public class DbAdressen : INotifyPropertyChanged
    {
        // Die Privaten Variablen zu den Properties.
        private ObjectId _id;
        private string _tellid;
        private string _tellFlag;
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

        // Die Id. Benutzt wird hier eine ObjectID
        public ObjectId Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        // Die TellId wird zusammengesatzt aus Vorname + Nachname + 3-Stellige Nummer
        // Das ist die primäre SuchId. 
        // Bspl.: "RolandKruggel824"
        public string TellId
        {
            get { return _tellid; }
            set
            {
                _tellid = value;
                OnPropertyChanged(nameof(TellId));
            }
        }

        // Das Tellflag ist 'y' wenn der aktuelle Datensatz gültig ist. 
        //  Sonst ist er 'n'.
        public string TellFlag
        {
            get { return _tellFlag; }
            set
            {
                _tellFlag = value;
                OnPropertyChanged(nameof(TellFlag));
            }
        }

        // Die Version
        // Bspl.: 5
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

        // true, wenn der User deaktiviert ist
        public bool Deaktiv
        {
            get => _deaktiv;
            set
            {
                _deaktiv = value;
                OnPropertyChanged(nameof(Deaktiv));
            }
        }

        // Wenn der Datensatz angelegt wird.
        // Bspl.: DateTime.Now.ToString("g")
        public DateTime Anlage
        {
            get => _anlage;
            set
            {
                _anlage = value;
                OnPropertyChanged(nameof(Anlage));
            }
        }

        // Wenn der Datensatz geändert wird.
        // Bspl.: DateTime.Now.ToString("g")
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
}
