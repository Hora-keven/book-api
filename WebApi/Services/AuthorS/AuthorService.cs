using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dto.Author;
using WebApi.Models;

namespace WebApi.Services.AuthorS
{
    public class AuthorService : IAuthorInterface
    {
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<Author>>> GetAllAuthors()
        {
            ResponseModel<List<Author>> response = new ResponseModel<List<Author>>();
            try
            {
                var authors = await _context.Authors.ToListAsync();
                response.Data = authors;
                response.Message = "All authors were collected.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }



        public async Task<ResponseModel<Author>> GetAuthorById(int authorId)
        {
            ResponseModel<Author> response = new ResponseModel<Author>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(each => each.Id == authorId);
                if (author == null)
                {
                    response.Message = "Author not found.";
                    return response;
                }
                response.Data = author;
                response.Message = "Author found by Id";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }
        public async Task<ResponseModel<Author>> GetAuthorByBookId(int bookId)
        {
            ResponseModel<Author> response = new ResponseModel<Author>();
            try
            {
                var book = await _context.Books.Include(author => author.Author).FirstOrDefaultAsync(book => book.Id == bookId);
                if (book == null)
                {

                    response.Message = "Book not found.";
                    return response;
                }
                response.Data = book.Author;
                response.Message = "Author found!";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<Author>>> CreateAuthor(CreateAuthorDto authorDto)
        {
            ResponseModel<List<Author>> response = new ResponseModel<List<Author>>();
            try
            {
                var author = new Author()
                {
                    Name = authorDto.Name,
                    Surname = authorDto.Surname,
                };
                _context.Add(author);
                await _context.SaveChangesAsync();
                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Author successfully created!";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<Author>>> EditAuthor(EditAuthorDto editAuthorDto)
        {
            ResponseModel<List<Author>> response = new ResponseModel<List<Author>>();
            try
            {
                var author =await _context.Authors.FirstOrDefaultAsync(each=>each.Id == editAuthorDto.Id);
                   if(author == null){
                    response.Message = "Author not found.";
                    return response;
                }
                author.Name = editAuthorDto.Name;
                author.Surname = editAuthorDto.Surname;
                 _context.Update(author);
                await _context.SaveChangesAsync();
                response.Data = await _context.Authors.ToListAsync();  
                response.Message = $"{editAuthorDto.Name} successfully updated!";
                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;
                return response;
            }

        }

        public async Task<ResponseModel<List<Author>>> DeleteAuthor(int authorId)
        {
              ResponseModel<List<Author>> response = new ResponseModel<List<Author>>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(each => each.Id == authorId);
                if(author == null){
                    response.Message = "Author not found.";
                    return response;
                }
                _context.Remove(author);
                await _context.SaveChangesAsync();
                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Author succesfully deleted!";
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
