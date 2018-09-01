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
    public class BookController : ApiController
    {
        private BookRepository bookRepository = new BookRepository();

        // GET api/<controller>
        public IEnumerable<Book> Get()
        {
            var books = bookRepository.GetAll();
            return books;
        }

        public IEnumerable<Book> Get(string search)
        {
            var books = bookRepository.GetAll().Where(x => x.BookTitle.Contains(search));
            return books;
        }

        // GET api/<controller>/5
        public Book Get(int id)
        {
            var book = bookRepository.GetById(id);
            return book;
        }

        // POST api/<controller>
        public int Post([FromBody]Book value)
        {
            bookRepository.Create(value);
            return value.Id;
        }

        // PUT api/<controller>/5
        public void Put([FromBody]Book value)
        {
            bookRepository.Update(value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            bookRepository.Delete(id);
        }
    }
}