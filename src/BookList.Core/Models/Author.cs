using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookList.Core.Models
{
    public class Author
    {
        public Guid AuthorId { get; set; }

        public Guid BookId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
