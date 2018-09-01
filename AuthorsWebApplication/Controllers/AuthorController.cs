using AuthorsWebApplication.Repositories;
using LibraryYTDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthorsWebApplication.Controllers
{
    public class AuthorController : ApiController
    {
        private AuthorRepository authorRepository = new AuthorRepository();

        // GET api/<controller>
        public IEnumerable<Author> Get()
        {
            var authors = authorRepository.GetAll();
            return authors;
        }

        // GET api/<controller>/5
        public Author Get(int id)
        {
            var author = authorRepository.GetById(id);
            return author;
        }

        // POST api/<controller>
        public int Post([FromBody]Author value)
        {
            authorRepository.Create(value);
            return value.Id;
        }

        // PUT api/<controller>/5
        public void Put([FromBody]Author value)
        {
            authorRepository.Update(value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            authorRepository.Delete(id);
        }
    }
}