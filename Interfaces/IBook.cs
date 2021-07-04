using BookCartApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartApi.Interfaces
{
    public interface IBook<TEntity> where TEntity : class
    {
        public Task<IEnumerable<Book>> GetBooks();
        public Task<Book> GetBook(int id);
    }
}
