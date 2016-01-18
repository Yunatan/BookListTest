namespace BookList.Core.Repositories
{
    public interface IRepositoryContainer
    {
        IAuthorRepository AuthorRepository { get; }

        IBookRepository BookRepository { get; }
    }
}
