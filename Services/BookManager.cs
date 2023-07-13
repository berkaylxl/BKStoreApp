﻿using Entities.Models;
using Repositories.Contract;
using Services.Contracts;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;

        public BookManager(IRepositoryManager manager, ILoggerService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public Book CreateOneBook(Book book)
        {
           _manager.Book.CreateOneBook(book);
           _manager.Save();
            return book;
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if(entity == null)
            {
                string message = $"The book with id:{id} could not found";
                _logger.LogInfo(message);
                throw new Exception(message);
            }
            _manager.Book.DeleteOneBook(entity);
            _manager.Save();
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return _manager.Book.GetAllBooks(trackChanges);
        }

        public Book GetOneBookById(int id, bool trackChanges)
        {
            return _manager.Book.GetOneBookById(id,trackChanges);
        }

        public void UpdateOneBook(int id, Book book, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity == null)
            {
                string message = $"The book with id:{id} could not found";
                _logger.LogInfo(message);
                throw new Exception(message);
            }
            if(book is null)
                throw new ArgumentNullException(nameof(book));

            entity.Title=book.Title;
            entity.Price=book.Price;

            _manager.Book.UpdateOneBook(entity);
            _manager.Save();
        }
    }
}
