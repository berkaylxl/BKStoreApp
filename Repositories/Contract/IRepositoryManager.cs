namespace Repositories.Contract
{
    public interface IRepositoryManager
    {
        IBookRepository Book { get; }
       Task SaveAsync();
    }
}
