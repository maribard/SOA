using LibraryYTDO;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCRUD
{
    public class BookRepository
    {
        private string _connectionPath = @"C:\Users\Mariusz\Desktop\book";

        public Book GetById(int id)
        {
            //zamayka bazę danych
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, kolekcja
                var repository = db.GetCollection<Book>();

                return repository.FindById(id);
            }
        }

        public List<Book> GetAll()
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Book>();

                return repository.FindAll().ToList();
            }
        }

        public int Create(Book book)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Book>();
                repository.Insert(book);

                return book.Id;
            }
        }

        public void Update(Book book)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Book>();
                repository.Update(book);

            }
        }

        public void Delete(int id)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Book>();
                repository.Delete(id);


            }
        }
    }
}
