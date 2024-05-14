using DataAccessLayer;
using Model;
using DTOModels;
using System.Data;


namespace BusinessLogic
{
    public class BusnessService
    {
        private IRepository<Book> bookRepository;
        private IRepository<User> userRepository;
        private IRepository<Reservation> reservationRepository;
        public BusnessService(IRepository<Book> bookRepository, IRepository<User> userRepository, IRepository<Reservation> reservationRepository)
        {
            this.bookRepository = bookRepository;
            this.userRepository = userRepository;
            this.reservationRepository = reservationRepository;
        }
        public void CreateUsers(string username,string password ,Role role)
        { var user = new User() { UserName = username, Password = password,Role=role };
           userRepository.Create(user);
        }
        public bool ValidateUser(string username, string password)
        {
            var users = userRepository.Read();
            var user = users.FirstOrDefault(u => u.UserName == username && u.Password==password);

            if (user != null )
            {
                // L'utente esiste e la password corrisponde, imposta come utente corrente
                UserSession.Instance.SetCurrentUser(user);
                return true;
            }

            return false;
        }
        public bool GetUserRole()
        {
            var role = UserSession.Instance.CurrentUser.Role;
            if (role == Role.Admin)
            {
                return true;
            }
            else { return false; }

        }
        public void CreateReservation(int userId, int bookId)
        {
            // Crea una nuova prenotazione
            var reservation = new Reservation
            {
                UserID = userId,
                BookID = bookId,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(30)
            };

            // Salva la nuova prenotazione utilizzando il DAL
            reservationRepository.Create(reservation);
        }
        public void CreateBook( string title, string authorName, string authorSurname, string publishingHouse, uint quantity)
        {
            // Crea un nuovo libro
            var book = new Book
            {
               
                Title = title,
                AuthorName = authorName,
                AuthorSurname = authorSurname,
                PublishingHouse = publishingHouse,
                Quantity = quantity
            };

            // Salva il nuovo libro utilizzando il DAL
            bookRepository.Create(book);
        }
        public Book FindBook(string title, string authorName, string authorSurname, string publishingHouse)
        {
            // Ottieni tutti i libri
            var books = bookRepository.Read();

            // Cerca il libro che corrisponde ai criteri
            var book = books.FirstOrDefault(b =>
                b.Title == title &&
                b.AuthorName == authorName &&
                b.AuthorSurname == authorSurname &&
                b.PublishingHouse == publishingHouse);

            // Restituisci il libro trovato o null se non esiste
            return book;
        }
        public bool IsDuplicate( string title, string authorName, string authorSurname, string publishingHouse)
        {
            // Ottieni tutti i libri
            var books = bookRepository.Read();

            // Conta quanti libri corrispondono ai criteri
            var count = books.Count(b =>
               
                b.Title == title &&
                b.AuthorName == authorName &&
                b.AuthorSurname == authorSurname &&
                b.PublishingHouse == publishingHouse);

            // Se il conteggio è maggiore di , allora il libro è un duplicato
            return count > 1;
        }
        public DtoRole MapRoleToDto(Role role)
        {
            switch (role)
            {
                case Role.Admin:
                    return DtoRole.Admin;
                case Role.User:
                    return DtoRole.User;
              
                default:
                    throw new ArgumentException("Invalid role");
            }
        }
        public User MapDtoToUser(UserDto userDto)
        {
            var user = new User
            {
                UserID = userDto.UserID,
                UserName = userDto.UserName,
                Password = userDto.Password,
                Role = (Role)userDto.Role 
            };

            return user;
        }

        public Book MapDtoToBook(BookDto bookDto)
        {
            var book = new Book
            {
               
                Title = bookDto.Title,
                AuthorName = bookDto.AuthorName,
                AuthorSurname = bookDto.AuthorSurname,
                PublishingHouse = bookDto.PublishingHouse,
                
               
            };

            return book;
        }
        public void CloseApplication()
        {
            Environment.Exit(0);
        }
       
    }
}
