using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace CinemaApp
{
    class Class1
    {
        string username, password, user;
        Guid Id;

        Cinema cinema = new Cinema();
        Account account = new Account();
        Movies movies = new Movies();
        Halls halls = new Halls();
        MovieHall movieHall = new MovieHall();
        MovieHallDetails MovieHallDetails = new MovieHallDetails();

        public Class1()
        {
            cinema.GenerateMovie();
            cinema.GenerateUser();
            //cinema.GenerateHall();
            //cinema.GenerateHallDetails();
            cinema.GenerateMovieHall();
        }
       
        public void FirstPage()
        {

            while (true)
            {
                Console.WriteLine("Welcome to Cinema Ticket App");
                Console.WriteLine("1. View All Movies");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit App");
                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        ShowMovie();
                        break;

                    case "2":
                        Console.Clear();
                        Console.Write("Username: ");
                        username = Console.ReadLine();
                        Console.Write("Password: ");
                        password = Console.ReadLine();
                        PassCheck();

                        break;

                    case "3":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Option.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        private void PassCheck()
        {
            var LinqCheck = (from c in cinema.User
                             where c.Username == username && c.Password == password
                             select c).FirstOrDefault();
            if (LinqCheck != null)
            {
                Console.Clear();
                user = LinqCheck.Username;
                UserInterface();

            }
            else
            {
                Console.WriteLine("Incorrect Username/Password");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ShowMovie()
        {
            var PrintMovie = from p in cinema.Movie
                             select p;

            var table = new ConsoleTable("ID", "Movie Title", "Release Date");
            foreach (var item in PrintMovie)
            {
                table.AddRow(item.Mid, item.Title, item.ReleaseDate);
            }
            table.Write();
            Console.ReadKey();
            Console.Clear();
            
        }

        private void UserInterface()
        {
            var checktrue = true;
            while (checktrue)
            {
                var AccountDetails = (from ad in cinema.User
                                      where ad.Username == username
                                      select ad).FirstOrDefault();

                Console.WriteLine("You login as " + AccountDetails.Username);
                Console.WriteLine("1. Select a movie");
                Console.WriteLine("2. Logout");
                Console.WriteLine("");
                Console.Write("Enter your option: ");
                string opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        Console.Clear();
                        SelectMovie();
                        break;

                    case "2":
                        user = null;
                        Console.Clear();
                        checktrue = false;
                        break;

                    default:
                        Console.WriteLine("Invalid Option.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        private void SelectMovie()
        {
            var PrintMovie = from p in cinema.Movie
                             select p;

            var table = new ConsoleTable("ID", "Movie Title", "Release Date");
            foreach (var item in PrintMovie)
            {
                table.AddRow(item.Mid, item.Title, item.ReleaseDate);
            }
            table.Write();
            Console.Write("Enter a movie Id: ");
            int movieOpt = Console.Read();

            var checkMovie = (from cm in cinema.MovieHalls
                             where cm.MovieId == movieOpt
                             select cm).SingleOrDefault();

            if (checkMovie != null)
            {
                var Movietable = new ConsoleTable("ID", "Movie Title", "Release Date");
                foreach (var item in checkMovie)
                {
                    table.AddRow(item.Id, item.MovieId, item.ShowTime);
                }
            }
        }
    }
}
