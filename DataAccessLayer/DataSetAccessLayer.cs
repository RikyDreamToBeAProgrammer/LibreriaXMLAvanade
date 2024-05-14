using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public abstract class DataSetAccessLayer
    {
        public static DataSetAccessLayer layer;
        public static DataSet libraryDataSet;// = new DataSet("Library");
        private string path = "Libreria.xml";
        

        public static DataSet GetDataSet()
        { if (libraryDataSet ==null)
            {  libraryDataSet = new DataSet("Library"); }

            return libraryDataSet; }
        public string GetPath() { return path; }

        public void LoadDataSet()
        {
            Console.WriteLine("Chiamata al metodo LoadDataSet...");
            if (File.Exists(path))
            {
                Console.WriteLine("Il file esiste, leggendo i dati...");
                libraryDataSet.ReadXml(path);
                Console.WriteLine("Dati caricati con successo.");
            }
            else
            {
                Console.WriteLine("Il file non esiste, nessun dato da caricare.");
            }
        }

        public void SaveDataSet()
        {
            Console.WriteLine("Chiamata al metodo SaveDataSet...");
            if (libraryDataSet.Tables.Count == 0)
            {
                Console.WriteLine("Il DataSet è vuoto. Nessun dato da salvare.");
                return;
            }
            libraryDataSet.WriteXml(path);
            Console.WriteLine("Dati salvati con successo.");
        }
        public void AddDataTable(DataTable table)
        {
            libraryDataSet.Tables.Add(table);
            SaveDataSet();
        }
        public int GetLastId(DataTable Table, string nameOfRow)
        {
            int lastId = 0;

            // Controlla se la tabella delle  ha delle righe
            if (Table.Rows.Count > 0)
            {
                lastId = Table.AsEnumerable()
                    .Max(row => int.Parse(row.Field<string>(nameOfRow)));
            }


            return lastId;
        }
        public DataTable CreateUsersTable()
        {
            // Crea una nuova DataTable
            DataTable usersTable = new DataTable("Users");

            // Aggiungi le colonne alla tabella
            usersTable.Columns.Add("UserID", typeof(int));
            usersTable.Columns.Add("UserName", typeof(string));
            usersTable.Columns.Add("Password", typeof(string));
            usersTable.Columns.Add("Role", typeof(Role));

            // Aggiungi la tabella al DataSet
            libraryDataSet.Tables.Add(usersTable);

            // Salva il DataSet
            SaveDataSet();
            return usersTable;
        }
        public DataTable CreatePrenotazioniTable()
        {
            // Crea una nuova DataTable
            DataTable prenotazioniTable = new DataTable("Reservations");

            // Aggiungi le colonne alla tabella
            prenotazioniTable.Columns.Add("Id", typeof(int));
            prenotazioniTable.Columns.Add("UserID", typeof(int));
            prenotazioniTable.Columns.Add("BookID", typeof(int));
            prenotazioniTable.Columns.Add("StartDate", typeof(DateTime));
            prenotazioniTable.Columns.Add("EndDate", typeof(DateTime));

            // Aggiungi la tabella al DataSet
            libraryDataSet.Tables.Add(prenotazioniTable);

            // Salva il DataSet
            SaveDataSet();
            return prenotazioniTable;
        }
        public DataTable CreateBooksTable()
        {
            // Crea una nuova DataTable
            DataTable booksTable = new DataTable("Books");

            // Aggiungi le colonne alla tabella
            booksTable.Columns.Add("BookId", typeof(int));
            booksTable.Columns.Add("Title", typeof(string));
            booksTable.Columns.Add("AuthorName", typeof(string));
            booksTable.Columns.Add("AuthorSurname", typeof(string));
            booksTable.Columns.Add("PublishingHouse", typeof(string));
            booksTable.Columns.Add("Quantity", typeof(uint));

            // Aggiungi la tabella al DataSet
            libraryDataSet.Tables.Add(booksTable);
            SaveDataSet();
            // Salva il DataSet
            return booksTable;
        }

    }
}

