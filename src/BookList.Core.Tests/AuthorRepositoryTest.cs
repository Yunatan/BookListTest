using System.Linq;
using BookList.Core.Models;
using BookList.Core.Repositories;
using BookList.Core.Repositories.Memory;
using NUnit.Framework;

namespace BookList.Core.Tests
{
    [TestFixture]
    public class AuthorRepositoryTest
    {
        private IAuthorRepository authorRepository;

        [SetUp]
        public void Setup()
        {
            var dataSource = new MemoryDataGenerator().Generate();
            authorRepository = new MemoryAuthorRepository(dataSource);
        }

        [Test]
        public void CanAddAndGetAuthorsOfBook()
        {
            var newAuthor = new Author
            {
                BookId = 2,
                FirstName = "Renée",
                LastName = "French"
            };

            authorRepository.AddAuthor(newAuthor);
            var authorList = authorRepository.GetAuthorsOfBook(2);
            var savedAuthor = authorList.Single(x => x.AuthorId.Equals(9));

            Assert.AreEqual(authorList.Count, 3);
            Assert.AreSame(newAuthor, savedAuthor);
        }

        [Test]
        public void CanUpdateAndGetAuthorsOfBook()
        {
            var authorList = authorRepository.GetAuthorsOfBook(3);

            var author = authorList.First();
            author.FirstName = "Andy";

            authorRepository.UpdateAuthor(author);
            authorList = authorRepository.GetAuthorsOfBook(3);

            Assert.AreEqual(authorList.Count, 2);
            Assert.AreEqual(authorList.First().FirstName, "Andy");
        }

        [Test]
        public void CanDeleteAndGetAuthorsOfBook()
        {
            var authorList = authorRepository.GetAuthorsOfBook(1);

            var author = authorList.First();

            authorRepository.DeleteAuthor(author.AuthorId);
            authorList = authorRepository.GetAuthorsOfBook(1);

            Assert.AreEqual(authorList.Count, 3);
            Assert.False(authorList.Contains(author));
        }
    }
}
