using Application.IService;
using Application.ViewModel;
using Domain.MsgErro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserViewModel userView)
        {
            if (userView == null) return this.StatusCode(StatusCodes.Status400BadRequest, MsgErro.ErroCadastroParametros);
            try
            {
                var respostaREQ = await _userService.Login(userView.Email, userView.Password);
                if(respostaREQ != null) return Ok(respostaREQ);
                return BadRequest("E-mail ou senha incorretos");
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, erro.Message);
            }
        }
    }
}
