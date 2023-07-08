using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contract
{
    public interface IBookRepository: IRepositoryBase<Book>
    {
        IQueryable<Book> GetAllBooks(bool trackChanges);
        IQueryable<Book> GetOneBookById(int id,bool trackChanges);
        void CreateOneBooks(Book book);
        void UpdateOneBooks(Book book);
        void DeleteOneBook(Book book);
    }
}
