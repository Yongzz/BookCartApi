using BookCartApi.Data;
using BookCartApi.Interfaces;
using BookCartApi.Models;
using BookCartApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCartApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBook<Book> _book;
        public BookService(BookContext context)
        { _book = new BookRepository(context); }
        public async Task<Book> GetBook(int id)
        {
            return await _book.GetBook(id);
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _book.GetBooks();
        }
    }
}
