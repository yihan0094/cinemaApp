using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp
{
    class Cinema
    {
        Random rnd = new Random();
        public ICollection<Account> User { get; set; }
        public ICollection<Movies> Movie { get; set; }
        public ICollection<Halls> Halls { get; set; }
        public ICollection<MovieHall> MovieHalls { get; set; }
        public ICollection<MovieHallDetails> MovieHallDetail { get; set; }

        public Cinema()
        {
            User = new List<Account>();
            Movie = new List<Movies>();
            MovieHalls = new List<MovieHall>();
        }

        public void GenerateUser()
        {
            User.Add(new Account() {
                Id = Guid.NewGuid(),
                Username = "nicholas",
                Password = "123123"
            });

            User.Add(new Account()
            {
                Id = Guid.NewGuid(),
                Username = "alex",
                Password = "456456"
            });
        }

        public void GenerateMovie()
        {
            Movie.Add(new Movies() {
                Id = Guid.NewGuid(),
                Mid = 101,
                Title = "John Wick",
                ReleaseDate = new DateTime(2020,3,10,0,0,0)
            });

            Movie.Add(new Movies()
            {
                Id = Guid.NewGuid(),
                Mid = 102,
                Title = "Ashfall",
                ReleaseDate = new DateTime(2020, 3, 10, 0, 0, 0)
            });
        }

        public void GenerateHall()
        {
            Halls.Add(new Halls()
            {
                Id= 001,
                HallNo = "001",
                TotalColumn = 10,
                TotalRow = 3

            });
        }

        public void GenerateMovieHall()
        {
            MovieHalls.Add(new MovieHall(){
                Id = 123,
                HallId = 001,
                MovieId = 102,
                ShowTime = new DateTime(2020,3,10,8,00,00)
            });
        }

        public void GenerateHallDetails()
        {
            MovieHallDetail.Add(new MovieHallDetails()
            {
                Id = 1,
                MovieHallId = 001,
                Seats = "taken", 
            });
        }
    }
}
