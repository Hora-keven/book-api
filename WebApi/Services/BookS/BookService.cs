using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dto.Book;
using WebApi.Models;
using WebApi.Services.BookS;

namespace WebApi.Services.BookS
{
    public class BookService : IBookInterface


    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<Book>>> CreateBook(CreateBookDto bookDto)
        {
            ResponseModel<List<Book>> response = new ResponseModel<List<Book>>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(eachBook => eachBook.Id == bookDto.AuthorId);
                if (author == null)
                {
                    response.Message = "Author not found!";
                    return response;
                }

                var book = new Book() { Author = author, Title = bookDto.Title };
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                response.Data = await _context.Books.ToListAsync();
                response.Message = "Book successfully created!";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }


        }

        public async Task<ResponseModel<List<Book>>> DeleteBook(int bookId)
        {
            ResponseModel<List<Book>> response = new ResponseModel<List<Book>>();

            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(each => each.Id == bookId);
                if (book == null)
                {
                    response.Message = "Book not found!";
                    return response;
                }
                _context.Remove(book);
                await _context.SaveChangesAsync();
                response.Data = await _context.Books.ToListAsync();
                response.Message = "Book successfully deleted!";
                return response;
            }

            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<Book>>> EditBook(EditBookDto editBookDto)
        {
            ResponseModel<List<Book>> response = new ResponseModel<List<Book>>();
            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(each => each.Id == editBookDto.Id);
                if (book == null)
                {
                    response.Message = "Book not found!";
                    response.Status = false;
                    return response;
                }
                book.Title = editBookDto.Title;
                _context.Update(book);
                await _context.SaveChangesAsync();
                response.Data = await _context.Books.ToListAsync();
                response.Message = "Book successfully edited.";
                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<Book>>> GetAllBooks()
        {
            ResponseModel<List<Book>> response = new ResponseModel<List<Book>>();
            try
            {
                var books = await _context.Books.ToListAsync();
                response.Data = books;
                response.Message = "All books returned.";
                return response;
            }

            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<Book>> GetBookById(int bookId)
        {
            ResponseModel<Book> response = new ResponseModel<Book>();
            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(each => each.Id == bookId);
                if (book == null)
                {
                    response.Message = "Book not found!";
                    response.Status = false;
                    return response;
                }
                response.Data = book;
                response.Message = "Book found!";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }

        }
    }
}