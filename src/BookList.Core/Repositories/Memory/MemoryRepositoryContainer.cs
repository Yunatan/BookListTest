namespace BookList.Core.Repositories.Memory
{
    public class MemoryRepositoryContainer : IRepositoryContainer
    {
        private readonly MemoryDataSource dataSource;

        public MemoryRepositoryContainer(MemoryDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public IAuthorRepository AuthorRepository => new MemoryAuthorRepository(dataSource);

        public IBookRepository BookRepository => new MemoryBookRepository(dataSource);
    }
}
