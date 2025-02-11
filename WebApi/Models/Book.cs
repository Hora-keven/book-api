using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dto.Book;

namespace WebApi.Models
{
    public class Book
    {
        public int Id{ get; set; }
        public string Title{ get; set; }
        public Author Author { get; set; }

   
    }
}