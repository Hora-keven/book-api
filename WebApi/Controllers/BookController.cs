using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Book;
using WebApi.Models;
using WebApi.Services.BookS;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookInterface _bookInterface;
        public BookController(IBookInterface bookInterface)
        {
            _bookInterface = bookInterface;
        }
        [HttpPost("/book")]
        public async Task<ActionResult<ResponseModel<List<Book>>>> CreateBook(CreateBookDto createBookDto){
            var books = await _bookInterface.CreateBook(createBookDto);
            var locationUri = Url.Action("GetBook", new { id = createBookDto.Title });
            return Created(locationUri, books);
        }
        [HttpGet("/books")]
        public async Task<ActionResult<ResponseModel<List<Book>>>> GetAllBooks(){
            var books = await _bookInterface.GetAllBooks();
            return Ok(books);
        }
        [HttpDelete("/{bookId}")]
        public async Task<ActionResult<ResponseModel<List<Book>>>> DeleteBook(int bookId){
            await _bookInterface.DeleteBook(bookId);
            return NoContent();
        }
        [HttpPut("/editBook")]
        public async Task<ActionResult<ResponseModel<List<Book>>>> EditBook(EditBookDto editBookDto){
            var books = await _bookInterface.EditBook(editBookDto);
            return Ok(books);
        }
        [HttpGet("/search/{bookId}")]
        public async Task<ActionResult<ResponseModel<Book>>> GetBookId(int bookId){
            var book = await _bookInterface.GetBookById(bookId);
            return Ok(book);
        }

    }
}