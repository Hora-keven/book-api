using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dto.Author;
using WebApi.Models;

namespace WebApi.Services.AuthorS
{
    public interface IAuthorInterface
    {
        Task<ResponseModel<List<Author>>> GetAllAuthors();
        Task<ResponseModel<Author>> GetAuthorById(int authorId);
        Task<ResponseModel<Author>> GetAuthorByBookId(int bookId);
        Task<ResponseModel<List<Author>>> CreateAuthor(CreateAuthorDto authorDto);
        Task<ResponseModel<List<Author>>> EditAuthor(EditAuthorDto editAuthorDto);
        Task<ResponseModel<List<Author>>> DeleteAuthor(int authorId);
    }
}