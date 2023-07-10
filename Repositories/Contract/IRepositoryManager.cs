namespace Repositories.Contract
{
    public interface IRepositoryManager
    {
        IBookRepository Book { get; }
        void Save();
    }
}
