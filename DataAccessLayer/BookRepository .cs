using System.Data;
using Model;
using static System.Reflection.Metadata.BlobBuilder;
namespace DataAccessLayer
{
    public class BookRepository : DataSetAccessLayer, IRepository<Book>
    {  // Fai riferimento al DataSet in GlobalData

        // Ottieni un'istanza di BookRepository


       

        public BookRepository()
        { // Imposta bookTable per fare riferimento alla tabella "Books" nel DataSet

            //if (!libraryDataSet.Tables.Contains("Books"))
            //{
            //    CreateBooksTable();
            //}



        }

        public void Create(Book obj)
        {


            // Controlla se il libro esiste già
            if (!BookExists(obj.Title, obj.AuthorName, obj.AuthorSurname, obj.PublishingHouse))
            {
                //  Console.WriteLine("Il libro non esiste, creazione di un nuovo libro...");
                LoadDataSet();
                       
                // Ottieni la tabella "Books" dal DataSet
                if (libraryDataSet.Tables["Books"] == null)

                {
                    CreateUsersTable();
                }


                var table = libraryDataSet.Tables["Books"];




                // Aggiungi una nuova riga alla tabella "Books"
                table.Rows.Add(GetLastId(table, "BookId") + 1, obj.Title, obj.AuthorName, obj.AuthorSurname, obj.PublishingHouse, obj.Quantity);
                SaveDataSet();


                //   Console.WriteLine("Libro creato con successo.");
            }
            else
            {
                //TODO: da aumentare la quantità
            }
        }






        private bool BookExists(string title, string authorName, string AuthorSurname, string PublishingHouse)
        {
            Console.WriteLine("Chiamata al metodo BookExists...");

            // Ottieni la tabella "Books" dal DataSet
            DataTable books = libraryDataSet.Tables["Books"];
            if (books == null)
            {
               var table= CreateBooksTable();
                books = table;
            }

            // Cerca un libro con gli stessi dettagli
            foreach (DataRow row in books.Rows)

            {
                Console.WriteLine("Controllo il libro: " + row["Title"].ToString());


                if (row["Title"].ToString() == title && row["AuthorName"].ToString() == authorName && row["AuthorSurname"].ToString() == AuthorSurname && row["PublishingHouse"].ToString() == PublishingHouse)

                {
                    // Se il libro esiste già, restituisci true
                    // Console.WriteLine("Il libro esiste già.");
                    return true;
                }
            }
            // Se non esiste nessun libro con gli stessi dettagli, restituisci false
            //Console.WriteLine("Il libro non esiste.");
            return false;
        }



        public void Delete(Book book)
        {


            // Ottieni la tabella "Books" dal DataSet
            DataTable books = libraryDataSet.Tables["Books"];
            // Trova la riga corrispondente alla prenotazione da eliminare
            DataRow rowToDelete = books.Rows.Find(book.BookId);

            if (rowToDelete != null)
            {
                // Rimuovi la riga dalla tabella delle prenotazioni
                books.Rows.Remove(rowToDelete);
                SaveDataSet();
            }
            else
            {
                throw new Exception("Book not found");
            }
        }



        public Book GetById(int id)
        {

            // Ottieni la tabella "Books" dal DataSet
            DataTable booksTable = libraryDataSet.Tables["Books"];

            // Trova la riga corrispondente al libro da ottenere
            DataRow rowToGet = booksTable.Rows.Find(id);

            if (rowToGet != null)
            {
                // Crea un nuovo libro e imposta le sue proprietà in base ai valori della riga
                var book = new Book
                {
                    BookId = int.Parse(rowToGet["BookId"].ToString()),
                    Title = rowToGet["Title"].ToString(),
                    AuthorName = rowToGet["AuthorName"].ToString(),
                    AuthorSurname = rowToGet["AuthorSurname"].ToString(),
                    PublishingHouse = rowToGet["PublishingHouse"].ToString(),
                    Quantity = uint.Parse(rowToGet["Quantity"].ToString())
                };

                // Restituisci il libro
                return book;
            }
            else
            {
                throw new Exception("Book not found");
            }
        }



        public IEnumerable<Book> Read()
        {

            // Crea una lista per contenere i libri
            var bookslist = new List<Book>();

            DataTable books = libraryDataSet.Tables["Books"];

            // Itera su ogni riga nella tabella dei libri
            foreach (DataRow row in books.Rows)
            {
                // Crea un nuovo libro e imposta le sue proprietà in base ai valori della riga
                var book = new Book
                {
                    BookId = int.Parse(row["BookId"].ToString()),
                    Title = row["Title"].ToString(),
                    AuthorName = row["AuthorName"].ToString(),
                    AuthorSurname = row["AuthorSurname"].ToString(),
                    PublishingHouse = row["PublishingHouse"].ToString(),
                    Quantity = uint.Parse(row["Quantity"].ToString())
                };

                // Aggiungi il libro alla lista
                bookslist.Add(book);
            }

            // Restituisci la lista di libri
            return bookslist;
        }




        public void Update(Book book)
        {
            // Ottieni la tabella "Books" dal DataSet
            DataTable books = libraryDataSet.Tables["Books"];

            // Trova la riga corrispondente al libro da aggiornare
            DataRow rowToUpdate = books.Rows.Find(book.BookId);



            // Aggiorna i valori dei campi per la riga
            rowToUpdate["Title"] = book.Title;
            rowToUpdate["AuthorName"] = book.AuthorName;
            rowToUpdate["AuthorSurname"] = book.AuthorSurname;
            rowToUpdate["PublishingHouse"] = book.PublishingHouse;
            rowToUpdate["Quantity"] = book.Quantity;

            SaveDataSet();


        }


    }
}
