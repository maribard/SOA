using MyMovieYDTO;
using MyPeopleCRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyPeopleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service2 : IService2
    {
        private MyPersonRespository repository = new MyPersonRespository();
        private MyReviewRespository reviewrepository = new MyReviewRespository();

        public int Create(Person Person)
        {
            return repository.Create(Person);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public List<Person> GetAll()
        {
            return repository.GetAll();
        }

        public Person GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Person Person)
        {
            repository.Update(Person);
        }



        public int CreateReview(Review review)
        {
            return reviewrepository.Create(review);
        }

        public void DeleteReview(int id)
        {
            reviewrepository.Delete(id);
        }

        public List<Review> GetAllReviews()
        {
            return reviewrepository.GetAll();
        }

        public List<Review> GetReviewsByAuthor(int authorId)
        {
            return reviewrepository.GetByAuthor(authorId);
        }

        //public MovieInfo GetMovieInfo(int movieId)
        //{
        // zeby uzyskac wszystkie informacje za jednym razem
        //}

        public List<Review> GetReviewsByMovie(int movieId)
        {
            return reviewrepository.GetByMovie(movieId);
        }

        public Review GetReviewById(int id)
        {
            return reviewrepository.GetById(id);
        }

        public void UpdateReview(Review review)
        {
            reviewrepository.Update(review);
        }

        public Person GetByName(string name, string surname)
        {
            var person = repository.GetAll().FirstOrDefault(x => x.Name == name && x.Surname == surname);
            if (person == null) // to znaczy ze uzytkownik o podanym imieniu nie isteje
            {
                person = new Person() { Name = name, Surname = surname };
                repository.Create(person);
            }

            return person;
        }
    }
}
