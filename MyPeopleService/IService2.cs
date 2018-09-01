using MyMovieYDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyPeopleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        Person GetById(int id);

        [OperationContract]
        Person GetByName(string name, string surname);

        [OperationContract]
        List<Person> GetAll();

        [OperationContract]
        int Create(Person Person);

        [OperationContract]
        void Update(Person Person);

        [OperationContract]
        void Delete(int id);


        [OperationContract]
        Review GetReviewById(int id);

        [OperationContract]
        List<Review> GetAllReviews();

        [OperationContract]
        List<Review> GetReviewsByAuthor(int authorId);

        [OperationContract]
        List<Review> GetReviewsByMovie(int movieId);

        [OperationContract]
        int CreateReview(Review review);

        [OperationContract]
        void UpdateReview(Review review);

        [OperationContract]
        void DeleteReview(int id);

    }
}
