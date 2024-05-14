using System.Data;
using BusinessLogic;
using Model;

namespace Delegates
{
    public class DelegatesBL
    {


        public DelegatesBL(BusnessService businesslogic)
        {
            // Assegna i metodi della tua classe di business logic alle istanze dei delegati
            LoginMethod = businesslogic.ValidateUser;
            RoleDelegate = businesslogic.GetUserRole;
            CreationReservationDelegate = businesslogic.CreateReservation;
            CreationBooksDelegate = businesslogic.CreateBook;
            FindBook = businesslogic.FindBook;
            IsDuplicate = businesslogic.IsDuplicate;
            MapDtOUser = businesslogic.MapDtoToUser;
            MapRoleToDtO = businesslogic.MapRoleToDto;
            MapDtoToBook = businesslogic.MapDtoToBook;
            ApplicationClose= businesslogic.CloseApplication;
            CreateUsers = businesslogic.CreateUsers;
        }

        // Definisci i delegati che corrispondono ai metodi della tua classe di business logic
        public delegate bool LoginDelegate(string username, string password);
        // Crea le istanze dei delegati
        public LoginDelegate LoginMethod { get; private set; }

        // Delegato per GetUserRole
        public delegate bool GetUserRoleDelegate();
        public GetUserRoleDelegate RoleDelegate { get; private set; }

        // Delegato per CreateReservation
        public delegate void CreateReservationDelegate(int userId, int bookId);
        public CreateReservationDelegate CreationReservationDelegate { get; private set; }

        // Delegato per CreateBook
        public delegate void CreateBookDelegate(string title, string authorName, string authorSurname, string publishingHouse, uint quantity);
        public CreateBookDelegate CreationBooksDelegate { get; private set; }
        // Delegato per FindBook
        public delegate Object FindBookDelegate(string title, string authorName, string authorSurname, string publishingHouse);
        public FindBookDelegate FindBook { get; private set; }
        // Delegato per IsDuplicate
        public delegate bool IsDuplicateDelegate(string title, string authorName, string authorSurname, string publishingHouse);
        public IsDuplicateDelegate IsDuplicate { get; private set; }
        // Delegato per MapRoleToDto
        public delegate DTOModels.DtoRole MapRoleToDtoDelegate(Model.Role role);
        public MapRoleToDtoDelegate MapRoleToDtO { get; private set; }
        // Delegato per MapDtoToUser
        public delegate User MapDtoToUserDelegate(DTOModels.UserDto userDto);
        public MapDtoToUserDelegate MapDtOUser { get; private set; }
        // Delegato per MapDtoToBook
        public delegate Book MapDtoToBookDelegate(DTOModels.BookDto bookDto);
        public MapDtoToBookDelegate MapDtoToBook { get; private set; }
        //Delegato èer chiudere l'app
        public delegate void CloseApplicationDelegate();
        public CloseApplicationDelegate ApplicationClose { get; private set; }
        //per creare un utente 
        public delegate void CreateUsersDelegate(string userName,string Password,Role role );
        public CreateUsersDelegate CreateUsers { get; private set; }
        // delegato per recuperare l ultimo id
        public delegate int LastIdObjectFound(DataTable Table, string nameOfRow);
        public LastIdObjectFound FindLastId {  get; private set; }
    }
}
