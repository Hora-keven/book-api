using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dto.Book;
using WebApi.Models;


namespace WebApi.Services.BookS
{
    public interface IBookInterface
    {
        Task<ResponseModel<List<Book>>> GetAllBooks();
        Task<ResponseModel<Book>> GetBookById(int bookId);
        // Task<ResponseModel<Book>> GetBookByBookId(int bookId);
        Task<ResponseModel<List<Book>>> CreateBook(CreateBookDto bookDto);
        Task<ResponseModel<List<Book>>> EditBook(EditBookDto editBookDto);
        Task<ResponseModel<List<Book>>> DeleteBook(int bookId);
    }
}