// See https://aka.ms/new-console-template for more information
using System.Data;
using BusinessLogic;
using ConsoleLibrary;
using DataAccessLayer;
using Model;

DataSet libraryDataSet = DataSetAccessLayer.GetDataSet();
//GlobalData.libraryDataSet =new System.Data.DataSet("Library");
IRepository<Reservation> reservationRepository = new ReservationRepository();
IRepository<User> userRepository = new UserRepository();
IRepository<Book> bookRepository = new BookRepository();
BusnessService service = new BusnessService(bookRepository, userRepository, reservationRepository);
Delegates.DelegatesBL delegatesBL = new Delegates.DelegatesBL(service);
ConsoleManager manager = new ConsoleManager(delegatesBL);
service.CreateUsers("Mario", "Rossi", Role.Admin);
//service.CreateUsers("Mirko", "Cossi", Role.User);

manager.DisplayMenu();
manager.ShowMenu();

