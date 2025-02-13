using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services.Token;

namespace WebApi.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly TokenGenerator _tokenGenerator;
        public IdentityController(TokenGenerator tokenGenerator){
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("/login"), AllowAnonymous]
        public ActionResult<LoginResponseModel> GenerateToken([FromBody] LoginRequestModel loginRequestModel)
        {
            var response = new LoginResponseModel() { Access_Token = _tokenGenerator.GenerateToken(loginRequestModel.Email!) };
            return Ok(response);
        }
    }
}