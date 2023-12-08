using Application.Filter;
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
    public class RoomController : ControllerBase
    {
        private IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("get-room-ativo")]
        public async Task<IActionResult> get()
        {
            try
            {
                var respostaREQ = await _roomService.GET_Room();
                return Ok(respostaREQ);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, erro.Message);
            }
        }

        [HttpGet("get-room-all/{hotelId}")]
        public async Task<IActionResult> getroom(int hotelId)
        {
            try
            {
                var respostaREQ = await _roomService.GET_RoomAll(hotelId);
                return Ok(respostaREQ);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, erro.Message);
            }
        }
        

        [HttpPost("set-room")]
        public async Task<IActionResult> Set([FromBody] RoomViewModel roomViewModel)
        {
            if (roomViewModel == null) return this.StatusCode(StatusCodes.Status400BadRequest, MsgErro.ErroCadastroParametros);
            try
            {
                var respostaREQ = await _roomService.SET_Room(roomViewModel);
                return Ok(respostaREQ);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, erro.Message);
            }
        }

        [HttpGet("update-status-room/{idRoom?}")]
        public async Task<IActionResult> update(int? idRoom)
        {
            if (idRoom == null) return this.StatusCode(StatusCodes.Status400BadRequest, MsgErro.ErroCadastroParametros);
            try
            {
                var respostaREQ = await _roomService.Modify_Status_Room((int)idRoom);
                return Ok(respostaREQ);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, erro.Message);
            }
        }

        [HttpPost("agendar-quarto")]
        public async Task<IActionResult> ReserveRoom([FromBody] RoomReserveDto RoomReserveDto)
        {
            if (RoomReserveDto == null) return this.StatusCode(StatusCodes.Status400BadRequest, MsgErro.ErroCadastroParametros);
            if(RoomReserveDto.DtInit == RoomReserveDto.DtEnd) return this.StatusCode(StatusCodes.Status400BadRequest, "Data de inicio e fim devem ser diferentes");
            try { 
                var respostaREQ = await _roomService.ReserveRoom(RoomReserveDto.RoomID, RoomReserveDto.UserID, RoomReserveDto.DtInit, RoomReserveDto.DtEnd);
                return Ok(respostaREQ);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, erro.Message);
            }
        }
        
        [HttpDelete("excluir-quarto/{roomId}")]
        public async Task<IActionResult> DeleteRoom(int roomId)
        {
            try
            {
                var respostaREQ = await _roomService.DeleteRoom(roomId);
                return Ok(respostaREQ);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, erro.Message);
            }
        }
    }
}