using LibraryYTDO;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorCRUD
{
    public class AuthorRepository
    {
        private string _connectionPath = @"C:\Users\Mariusz\Desktop\author";

        public Author GetById(int id)
        {
            //zamayka bazę danych
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, kolekcja
                var repository = db.GetCollection<Author>();

                return repository.FindById(id);
            }
        }

        public List<Author> GetAll()
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Author>();

                return repository.FindAll().ToList();
            }
        }

        public int Create(Author author)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Author>();
                repository.Insert(author);

                return author.Id;
            }
        }

        public void Update(Author author)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Author>();
                repository.Update(author);

            }
        }

        public void Delete(int id)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Author>();
                repository.Delete(id);


            }
        }
    }
}
