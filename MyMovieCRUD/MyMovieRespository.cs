using LiteDB;
using MyMovieYDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieCRUD
{
    public class MyMovieRespository
    {
        private string _connectionPath = @"C:\Users\Mariusz\Desktop\movie";

        public Movie GetById(int id)
        {
            //zamayka bazę danych
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, kolekcja
                var repository = db.GetCollection<Movie>();

                return repository.FindById(id);
            }
        }

        public List<Movie> GetAll()
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Movie>();

                return repository.FindAll().ToList();
            }
        }

        public int Create(Movie movie)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Movie>();
                repository.Insert(movie);

                return movie.Id;
            }
        }

        public void Delete(int id)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Movie>();
                repository.Delete(id);


            }
        }

        public void Update(Movie movie)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Movie>();
                repository.Update(movie);

            }
        }
    }
}
