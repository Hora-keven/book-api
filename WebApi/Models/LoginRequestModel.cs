using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class LoginRequestModel
    {
        public string? UserName {get;set;}
        public string? Email {get;set;}
        public string? Password {get;set;}
        public required List<Claim> customClaims;
    }
}