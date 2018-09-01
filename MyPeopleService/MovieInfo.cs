using MyMovieYDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPeopleService
{
    public class MovieInfo
    {
        public Movie Movie { get; set; }
        public double AverageScore { get; set; }
        public List<Review> Reviews { get; set; }
    }
}