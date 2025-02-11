using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
        [JsonIgnore]
        public ICollection<Book> books { get; set; }
    }
}