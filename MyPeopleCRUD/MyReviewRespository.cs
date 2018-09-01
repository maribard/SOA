using LiteDB;
using MyMovieYDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPeopleCRUD
{
    public class MyReviewRespository
    {
        private string _connectionPath = @"C:\Users\Mariusz\Desktop\Review";

        public Review GetById(int id)
        {


            //zamayka bazę danych
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, kolekcja
                var repository = db.GetCollection<Review>();

                return repository.FindById(id);
            }
        }

        public List<Review> GetAll()
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Review>();

                return repository.FindAll().ToList();
            }
        }

        public List<Review> GetByAuthor(int authorId)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                var repository = db.GetCollection<Review>();
                return repository.Find(x => x.Author.Id == authorId).ToList();
            }
        }

        public List<Review> GetByMovie(int movieId)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                var repository = db.GetCollection<Review>();
                return repository.Find(x => x.MovieId == movieId).ToList();
            }
        }

        public int Create(Review Review)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Review>();
                repository.Insert(Review);

                return Review.Id;
            }
        }

        public void Update(Review Review)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Review>();
                repository.Update(Review);

            }
        }

        public void Delete(int id)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Review>();
                repository.Delete(id);


            }
        }
    }
}
