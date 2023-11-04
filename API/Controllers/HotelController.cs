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
    public class HotelController : ControllerBase
    {
        private IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost("set-hotel")]
        public async Task<IActionResult> Set([FromBody] HotelViewModel hotelViewModel)
        {
            if (hotelViewModel == null) return this.StatusCode(StatusCodes.Status400BadRequest, MsgErro.ErroCadastroParametros);
            try
            {
                var respostaREQ = await _hotelService.SET_Hotel(hotelViewModel);
                return Ok(respostaREQ);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, erro.Message);
            }
        }
    }
}
