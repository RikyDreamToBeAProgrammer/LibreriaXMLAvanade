using Model;
using System.Data;


namespace DataAccessLayer
{
    public class UserRepository : DataSetAccessLayer, IRepository<User>
    {


        public UserRepository()
        {


            //if (!libraryDataSet.Tables.Contains("Users"))
            //{
            //    CreateUsersTable();
            //}
        }
        public IEnumerable<User> Read()
        {    
            // Crea una lista per contenere gli utenti
            var users = new List<User>();

          ; //Libreria è il mio dataset
            // Itera su ogni riga nella tabella degli utenti
            libraryDataSet.ReadXml("Libreria.xml");
            foreach (DataRow row in  libraryDataSet.Tables["Users"].Rows)
            {//Parse.row["UserID"],
                // Crea un nuovo utente e imposta le sue proprietà in base ai valori della riga
                var user = new User()
                {
                    UserID = int.Parse(row["UserID"].ToString()),
                    UserName = (string)row["UserName"],
                    Password = (string)row["Password"],
                    Role  = (Role)Enum.Parse(typeof(Role), row["Role"].ToString())
            };

                // Aggiungi l'utente alla lista
                users.Add(user);
            }

            // Restituisci la lista di utenti
            return users;
        }




        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(User obj)
        {
           

            // Controlla se l'utente esiste già
            if (!UserExists(obj.UserName))
            {
                Console.WriteLine("L'utente non esiste, creazione di un nuovo utente...");

                if (libraryDataSet.Tables["Users"]==null)
                {
                  CreateUsersTable();
                }

                // Ottieni la tabella "Users" dal DataSet
              var table=  libraryDataSet.Tables["Users"];

                // Aggiungi una nuova riga alla tabella "Users"
                table.Rows.Add(GetLastId(table, "UserID") + 1, obj.UserName, obj.Password, obj.Role);

                Console.WriteLine("Utente creato con successo.");

                SaveDataSet();
            }
            else
            {
                Console.WriteLine("L'utente esiste già.");
            }
        }


       
        public bool UserExists(string username)
        {
            Console.WriteLine("Chiamata al metodo UserExists...");

            

            // Ottieni la tabella "Users" dal DataSet
            DataTable usersTable = libraryDataSet.Tables["Users"];
            if(usersTable==null)
            {
                var table=CreateUsersTable();
                usersTable = table;
            }

            // Cerca un utente con lo stesso nome utente
            foreach (DataRow row in usersTable.Rows)
            {
                Console.WriteLine("Controllo l'utente: " + row["UserName"].ToString());

                if (row["UserName"].ToString() == username)
                {
                    // Se l'utente esiste già, restituisci true
                    Console.WriteLine("L'utente esiste già.");
                    return true;
                }
            }

            // Se non esiste nessun utente con lo stesso nome utente, restituisci false
            Console.WriteLine("L'utente non esiste.");
            return false;
        }

         public void Update(User obj)
        {
            throw new NotImplementedException();
        }



        public void Delete(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
