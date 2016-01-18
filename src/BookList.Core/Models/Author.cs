using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList.Core.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        public int BookId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
