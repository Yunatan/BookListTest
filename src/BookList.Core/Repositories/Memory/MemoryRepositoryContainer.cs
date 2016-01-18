namespace BookList.Core.Repositories.Memory
{
    public class MemoryRepositoryContainer : IRepositoryContainer
    {
        private readonly MemoryDataSource _dataSource;

        public MemoryRepositoryContainer(MemoryDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public IAuthorRepository AuthorRepository => new MemoryAuthorRepository(_dataSource);

        public IBookRepository BookRepository => new MemoryBookRepository(_dataSource);
    }
}
