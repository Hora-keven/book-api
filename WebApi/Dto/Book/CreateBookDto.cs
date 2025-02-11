using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto.Book
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public int AuthorId {get; set;}
    }
}