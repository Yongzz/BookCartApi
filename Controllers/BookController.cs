using BookCartApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookCartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("GetBook/{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var Items = await _bookService.GetBook(id);
            return Ok(Items);
        }  
        [HttpGet("GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            var Items = await _bookService.GetBooks();
            return Ok(Items);
        }
    }
}
