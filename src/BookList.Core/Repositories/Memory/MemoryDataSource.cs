using System.Collections.Generic;
using BookList.Core.Models;

namespace BookList.Core.Repositories.Memory
{
    public class MemoryDataSource
    {
        public List<Book> Books { get; private set; }

        public List<Author> Authors { get; private set; }

        public MemoryDataSource()
        {
            Books = new List<Book>();
            Authors = new List<Author>();
        }
    }
}
