using MyMovieYDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyMovieService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Movie GetById(int id);

        [OperationContract]
        List<Movie> GetAll();

        [OperationContract]
        int Create(Movie movie);

        [OperationContract]
        void Update(Movie movie);

        [OperationContract]
        void Delete(int id);

    }
}
