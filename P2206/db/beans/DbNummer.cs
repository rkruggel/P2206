#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
using LiteDB;

namespace P2206.db
{
    public class DbNummer
    {
        public ObjectId Id { get; set; }
        public string TObject { get; set; }

        public int Nummer { get; set; }
    }
}

