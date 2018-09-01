using LibraryYTDO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuthorsWebApplication.DAL
{
    public class BookInitializer : DropCreateDatabaseIfModelChanges<BookContext>
    //public class BookInitializer : DropCreateDatabaseAlways<BookContext> //!!! ZA PIERWSZYM RAZEM MA BYC TAK!
    {
        protected override void Seed(BookContext context)
        {
            var auhtor = new Author() { AuthorName = "Henryk", AuthorSurname = "Sienkiewicz" };
            context.Authors.Add(auhtor);
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book() { AuthorId = auhtor.Id, BookTitle = "Ogniem i mieczem", ISBN = "232332" },
                new Book() { AuthorId = auhtor.Id, BookTitle = "W pustyni i w puszczy", ISBN = "7868678" }
            };
            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();
        }
    }
}