using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Author;
using WebApi.Models;
using WebApi.Services.AuthorS;

namespace WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorInterface _authorInterface;
        public AuthorController(IAuthorInterface authorInterface)
        {
            _authorInterface = authorInterface;
        }
        [HttpGet("/authors")]
        public async Task<ActionResult<ResponseModel<List<Author>>>> GetAllAuthors()
        {
            var authors = await _authorInterface.GetAllAuthors();
            return Ok(authors);
        }
        [HttpGet("/author/{id}")]
        public async Task<ActionResult<ResponseModel<Author>>> GetAuthorById(int id)
        {
            var author = await _authorInterface.GetAuthorById(id);
            return Ok(author);
        }
        [HttpGet("/authorByBookId/{id}")]
        public async Task<ActionResult<ResponseModel<Author>>> GetAuthorByBookId(int id)
        {
            var author = await _authorInterface.GetAuthorByBookId(id);
            return Ok(author);
        }
        [HttpPost("/createAuthor")]
        public async Task<ActionResult<ResponseModel<List<Author>>>> CreateAuthor(CreateAuthorDto authorDto)
        {
            var authors = await _authorInterface.CreateAuthor(authorDto);
            var locationUri = Url.Action("GetAuthor", new { id = authorDto.Name });
            return Created(locationUri, authors);

        }
        [HttpPut("/editAuthor")]
        public async Task<ActionResult<ResponseModel<List<Author>>>> EditAuthor(EditAuthorDto authorDto)
        {
            var authors = await _authorInterface.EditAuthor(authorDto);
            return Ok(authors);

        }
        [HttpDelete("/deleteAuthor/{authorId}")]
        public async Task<ActionResult<ResponseModel<List<Author>>>> DeleteAuthor(int authorId)
        {
            var authors = await _authorInterface.DeleteAuthor(authorId);
            return Ok(authors);

        }
    }
}