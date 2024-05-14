

using BusinessLogic;
using Delegates;
using DTOModels;
using Model;




namespace ConsoleLibrary
{
    public class ConsoleManager
    {
        private DelegatesBL delegates;

        public ConsoleManager(DelegatesBL delegates)
        {
            this.delegates = delegates;
        }

        public void PrintBookDetails(Book book)
        {
            // Controlla se il libro esiste
            if (book != null)
            {
                // Stampa le informazioni del libro
                Console.WriteLine($"Titolo: {book.Title}");
                Console.WriteLine($"Nome Autore: {book.AuthorName}");
                Console.WriteLine($"Cognome Autore: {book.AuthorSurname}");
                Console.WriteLine($"Casa Editrice: {book.PublishingHouse}");

            }
            else
            {
                // Stampa un messaggio se il libro non viene trovato
                Console.WriteLine("Libro non trovato.");
                return;
            }
        }
        public void PrintBookDuplicateInfo(bool isDuplicate)
        {
            if (isDuplicate)
            {
                // Stampa un messaggio se il libro è un duplicato
                Console.WriteLine("Il libro è un duplicato.");
            }
            else { return; }
        }
        public void PrintUpdateMessage()
        {
            Console.WriteLine("Libro aggiornato");
        }
        public BookDto GetBookDetailsFromUser()
        {


            Console.Write("Inserisci il titolo del libro: ");
            string title = Console.ReadLine();

            Console.Write("Inserisci il nome dell'autore: ");
            string authorName = Console.ReadLine();

            Console.Write("Inserisci il cognome dell'autore: ");
            string authorSurname = Console.ReadLine();

            Console.Write("Inserisci la casa editrice: ");
            string publishingHouse = Console.ReadLine();

            var bookDto = new BookDto
            {

                Title = title,
                AuthorName = authorName,
                AuthorSurname = authorSurname,
                PublishingHouse = publishingHouse
            };

            return bookDto;
        }
        public void DisplayMenu()
        {
            bool isLoggedIn = false;
            do
            {
                Console.WriteLine("Benvenuto nella Libreria scegli un'opzione:");
                Console.WriteLine("1. Login ");
                Console.WriteLine("2. Esci");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    isLoggedIn = DisplayMenuLogin();
                }
                else if (choice == "2")
                {
                    DisplayMenuExit();
                }
                else
                {
                    Console.WriteLine("Scelta non valida. Per favore, scegli un'opzione tra 1, 2 .");
                }

            } while (!isLoggedIn);
        }


        public bool DisplayMenuLogin()
        {
            bool loginSuccessful = false;
            do
            {
                Console.Write("Inserisci il tuo username: ");
                string username = Console.ReadLine();

                Console.Write("Inserisci la tua password: ");
                string password = Console.ReadLine();

                // Verifica l'username e la password
                loginSuccessful = delegates.LoginMethod(username, password);

                if (loginSuccessful)
                {
                    Console.WriteLine($"Login effettuato con successo! benvenuto:{UserSession.Instance.CurrentUser.Role}-->{UserSession.Instance.CurrentUser.UserName}<--");
                    return true;
                }
                if (!loginSuccessful)
                {
                    Console.WriteLine("Username o password errati. premi un qualsiasi tasto per riprovare o premi 2 uscire dall'applicazione  .");
                    string choiche = Console.ReadLine();
                    if (choiche == "2") { delegates.ApplicationClose(); }
                }
            } while (!loginSuccessful);
            return false;
        }

        public void DisplayMenuExit()
        {
            delegates.ApplicationClose();
        }
        public void ShowMenuUser()
        {
            Console.WriteLine("Per uscire dall'applicazione premi 0");
            Console.WriteLine("Per visualizzare tutti i libri premi 1");
            Console.WriteLine("Per cercare un singolo libro premi 2");
            Console.WriteLine("Per prenotare un libro premi 3");
            Console.WriteLine("Per restituire un libro premi 4");
            Console.WriteLine("Per visualizzare il tuo storico delle prenotazioni  premi 5");
        }
        public void ShowMenuAdmin()
        {
            Console.WriteLine("Per uscire dall'applicazione premi 0");
            Console.WriteLine("Per visualizzare tutti i libri premi 1");
            Console.WriteLine("Per cercare un singolo libro premi 2");
            Console.WriteLine("Per prenotare un libro premi 3");
            Console.WriteLine("Per restituire un libro premi 4");
            Console.WriteLine("Per visualizzare il tuo storico delle prenotazioni  premi 5");
            Console.WriteLine("Per visualizzare lo storico delle prenotazioni della libreria premi 6");
            Console.WriteLine("Per rimuovere un libro dalla libreria premi 7");
            Console.WriteLine("Per modificare l'anagrafica di un libro dalla libreria premi 8");
            Console.WriteLine("Per inserire un libro nella libreria premi 9");
        }
        public void ShowMenu()
        {
            var role = delegates.RoleDelegate();
            if (role)
            {
                ShowMenuAdmin();
                HandleMenuChoiceAdmin();
            }
            if (!role)
            {
                ShowMenuUser();
                HandleMenuChoiceUser();
            }
        }
        private void HandleMenuChoiceAdmin()
        {
            do
            {
                Console.WriteLine("Inserisci la tua scelta: ricorda 0 è per uscire");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        delegates.ApplicationClose();
                        break;
                    case "1":
                        // Codice per visualizzare tutti i libri
                        break;
                    case "2":
                        // Codice per cercare un singolo libro
                        break;
                    case "3":
                        // Codice per prenotare un libro
                        break;
                    case "4":
                        // Codice per restituire un libro
                        break;
                    case "5":
                        // Codice per visualizzare lo storico delle prenotazioni dell'utente
                        break;
                    case "6":
                        // Codice per visualizzare lo storico delle prenotazioni della libreria
                        break;
                    case "7":
                        // Codice per rimuovere un libro dalla libreria
                        break;
                    case "8":
                        // Codice per modificare l'anagrafica di un libro
                        // Codice per inserire un libro nella libreria
                        // Nota: hai usato "8" per due opzioni diverse nel tuo menu
                        break;
                    case "9":

                        delegates.CreationBooksDelegate(GetTitle(),GetAuthorName(),GetAuthorSurname(),GetPublishingHouse(),GetQuantity());
                        // Codice per inserire l'anagrafica di un libro
                        // Codice per inserire un libro nella libreria
                        // 
                        break;
                    default:
                        Console.WriteLine("Scelta non valida. Per favore, scegli un'opzione tra 0 e 9.");
                        break;
                }
            } while (true);

        }
        private void HandleMenuChoiceUser()
        {
            do
            {
               
                Console.WriteLine("Inserisci la tua scelta: ricorda 0 è per uscire");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        delegates.ApplicationClose();
                        break;
                    case "1":
                        // Codice per visualizzare tutti i libri

                        break;
                    case "2":
                        // Codice per cercare un singolo libro
                        break;
                    case "3":
                        // Codice per prenotare un libro
                        break;
                    case "4":
                        // Codice per restituire un libro
                        break;
                    case "5":
                        // Codice per visualizzare lo storico delle prenotazioni dell'utente
                        break;
                  
                        
                    default:
                        Console.WriteLine("Scelta non valida. Per favore, scegli un'opzione tra 0 e 5.");
                        break;
                }
            } while (true);

        }
        private string GetTitle()
        {
            Console.WriteLine("Inserisci il titolo:");
            string title = Console.ReadLine();
            return title;
        }

        private string GetAuthorName()
        {
            Console.WriteLine("Inserisci il nome dell'autore:");
            string authorName = Console.ReadLine();
            return authorName;
        }

        private string GetAuthorSurname()
        {
            Console.WriteLine("Inserisci il cognome dell'autore:");
            string authorSurname = Console.ReadLine();
            return authorSurname;
        }

        private string GetPublishingHouse()
        {
            Console.WriteLine("Inserisci la casa editrice:");
            string publishingHouse = Console.ReadLine();
            return publishingHouse;
        }

        private uint GetQuantity()
        {
             Console.WriteLine("Inserisci la quantità:");
            uint quantity = 0;
            if (uint.TryParse(Console.ReadLine(), out uint result))
            {
                quantity = result;
            }
            else
            {
                Console.WriteLine("Quantità non valida. Riprova.");
            }
            return quantity;
        }

    }
}
