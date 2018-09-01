using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryYTDO
{
    public class Book
    {
        public int Id { set; get; }
        public int AuthorId { set; get; }
        public string BookTitle { set; get; }
        public string ISBN { set; get; }
    }
}
