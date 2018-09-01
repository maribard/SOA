using LiteDB;
using MyMovieYDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPeopleCRUD
{
    public class MyPersonRespository
    {
        private string _connectionPath = @"C:\Users\Mariusz\Desktop\Person";

        public Person GetById(int id)
        {
            //zamayka bazę danych
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, kolekcja
                var repository = db.GetCollection<Person>();

                return repository.FindById(id);
            }
        }

        public List<Person> GetAll()
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Person>();

                return repository.FindAll().ToList();
            }
        }

        public int Create(Person Person)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Person>();
                repository.Insert(Person);

                return Person.Id;
            }
        }

        public void Update(Person Person)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Person>();
                repository.Update(Person);

            }
        }

        public void Delete(int id)
        {
            using (var db = new LiteDatabase(_connectionPath))
            {
                //odnośnik do repozytorium, , kolekcja
                var repository = db.GetCollection<Person>();
                repository.Delete(id);


            }
        }
    }
}

