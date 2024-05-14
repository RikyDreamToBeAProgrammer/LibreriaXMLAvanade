using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*namespace DataAccessLayer
/*{
   /* public static class GlobalData
    {
     //   public static DataSet libraryDataSet = new DataSet("Library");

        static GlobalData()
        {
            if (File.Exists("Libreria.xml"))
            {
                // Se il file esiste, carica il DataSet da esso
                try
                {
                    libraryDataSet.ReadXml("Libreria.xml");
                    Console.WriteLine("DataSet caricato con successo da Libreria.xml");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Errore durante il caricamento del DataSet: " + ex.Message);
                }
            }
            else
            {
                // Se il file non esiste, crea un nuovo DataSet e salvalo come file XML
                try
                {
                    // Creazione del DataTable Users
                    DataTable users = new DataTable("Users");
                    users.Columns.Add("UserID", typeof(int));
                    users.Columns.Add("UserName", typeof(string));
                    users.Columns.Add("Password", typeof(string));
                    users.Columns.Add("Role", typeof(Enum)); // Assumendo che Role sia una stringa

                    // Creazione del DataTable Books
                    DataTable books = new DataTable("Books");
                    books.Columns.Add("BookId", typeof(int));
                    books.Columns.Add("Title", typeof(string));
                    books.Columns.Add("AuthorName", typeof(string));
                    books.Columns.Add("AuthorSurname", typeof(string));
                    books.Columns.Add("PublishingHouse", typeof(string));
                    books.Columns.Add("Quantity", typeof(uint));

                    // Creazione del DataTable Reservations
                    DataTable reservations = new DataTable("Reservations");
                    reservations.Columns.Add("Id", typeof(int));
                    reservations.Columns.Add("UserID", typeof(int));
                    reservations.Columns.Add("BookID", typeof(int));
                    reservations.Columns.Add("StartDate", typeof(DateTime));
                    reservations.Columns.Add("EndDate", typeof(DateTime));

                    // Aggiunta dei DataTable al DataSet
                    libraryDataSet.Tables.Add(users);
                    libraryDataSet.WriteXml("Libreria.xml");
                    libraryDataSet.Tables.Add(books);
                    libraryDataSet.WriteXml("Libreria.xml");
                    libraryDataSet.Tables.Add(reservations);

                    libraryDataSet.WriteXml("Libreria.xml");
                    Console.WriteLine("Nuovo DataSet creato e salvato come Libreria.xml");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Errore durante la creazione del DataSet: " + ex.Message);
                }
            }
        }
    }

}




*/
