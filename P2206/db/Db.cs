#pragma warning disable CS8618 // Ein Non-Nullable-Feld muss beim Beenden des Konstruktors einen Wert ungleich NULL enthalten. Erwägen Sie die Deklaration als Nullable.
using P2206.db.beans;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using LiteDB;


namespace P2206.db
{

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
