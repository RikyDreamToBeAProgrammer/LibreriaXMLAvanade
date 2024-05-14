
using System.Data;
using Model;


namespace DataAccessLayer
{
    public class ReservationRepository : DataSetAccessLayer,IRepository<Reservation>
    {
        
        public ReservationRepository()
        {
            //if (!libraryDataSet.Tables.Contains("Reservations"))
            //{
            //    CreatePrenotazioniTable();
            //}

        }

       

        public void Create(Reservation reservation)
        {
            DataTable reservations = libraryDataSet.Tables["Reservations"];
            // Ottieni l'ultimo ID delle prenotazioni e incrementalo di 1
            int newId = GetLastId(reservations, "Id") + 1;

            // Crea una nuova riga nella tabella delle prenotazioni
            DataRow newRow = reservations.NewRow();

            // Imposta i valori dei campi per la nuova riga
            newRow["Id"] = newId;
            newRow["UserID"] = reservation.UserID;
            newRow["BookID"] = reservation.BookID;
            newRow["StartDate"] = reservation.StartDate;
            newRow["EndDate"] = reservation.EndDate;

            // Aggiungi la nuova riga alla tabella delle prenotazioni
            reservations.Rows.Add(newRow);
            SaveDataSet();

        }

        

     


       
        public void Delete(Reservation reservation)
        {


            DataTable reservations = libraryDataSet.Tables["Reservations"];
            // Trova la riga corrispondente alla prenotazione da eliminare
            DataRow rowToDelete = reservations.Rows.Find(reservation.Id);

            if (rowToDelete != null)
            {
                // Rimuovi la riga dalla tabella delle prenotazioni
                reservations.Rows.Remove(rowToDelete);
               SaveDataSet();
            }
            else
            {
                throw new Exception("Reservation not found");
            }
        }

        public Reservation GetById(int id)
        {

            // Accedi alla tabella delle prenotazioni nel DataSet
            DataTable reservations = libraryDataSet.Tables["Reservations"];

            // Trova la riga corrispondente alla prenotazione da ottenere
            DataRow rowToGet = reservations.Rows.Find(id);

            if (rowToGet != null)
            {
                // Crea una nuova prenotazione e imposta le sue proprietà in base ai valori della riga
                var reservation = new Reservation
                {
                    Id = int.Parse(rowToGet["Id"].ToString()),
                    UserID = int.Parse(rowToGet["UserID"].ToString()),
                    BookID = int.Parse(rowToGet["BookID"].ToString()),
                    StartDate = DateTime.Parse(rowToGet["StartDate"].ToString()),
                    EndDate = DateTime.Parse(rowToGet["EndDate"].ToString())
                };

                // Restituisci la prenotazione
                return reservation;
            }
            else
            {
                throw new Exception("Reservation not found");
            }
        }

        public IEnumerable<Reservation> Read()
        {
            DataTable reservations = libraryDataSet.Tables["Reservations"];
            // Crea una lista per contenere gli utenti
            var reservationsList = new List<Reservation>();

            // Itera su ogni riga nella tabella degli utenti
            foreach (DataRow row in reservations.Rows)
            {
                // Crea un nuovo utente e imposta le sue proprietà in base ai valori della riga
                var reservation = new Reservation
                {
                    // Aggiungi qui le proprietà dell'utente
                };

                // Aggiungi l'utente alla lista
                reservationsList.Add(reservation);
            }

            // Restituisci la lista di utenti
            return reservationsList;
        }
        public void Update(Reservation reservation)
        {
            // Carica il DataSet se non è già stato caricato

            DataTable reservations = libraryDataSet.Tables["Reservations"];
            // Accedi alla tabella delle prenotazioni nel DataSet


            // Trova la riga corrispondente alla prenotazione da aggiornare
            DataRow rowToUpdate = reservations.Rows.Find(reservation.Id);

            if (rowToUpdate != null)
            {
                // Aggiorna i valori dei campi per la riga
               
                
                rowToUpdate["EndDate"] = reservation.EndDate;

                // Salva il DataSet nel file XML
                SaveDataSet();
            }
            else
            {
                throw new Exception("Reservation not found");
            }
        }

    }
}
