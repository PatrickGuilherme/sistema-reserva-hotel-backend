using Application.IService;
using Application.ViewModel;
using AutoMapper;
using Domain.MsgErro;
using Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class RoomService : IRoomService
    {
        public readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private List<RoomViewModel> _lista_teste;
        private bool _test = false;

        public RoomService(List<RoomViewModel> lista_teste, bool test)
        {
            _lista_teste = lista_teste;
            _test = test;
        }

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomViewModel>> GET_Room()
        {
           var dataReturn =  await _roomRepository.GET_Room(null, null, null, null, false);
           if(dataReturn == null) throw new Exception(MsgErro.ErroConsultaBancoDados);

            return _mapper.Map<IEnumerable<RoomViewModel>>(dataReturn);
        }

        public async Task<IEnumerable<RoomViewModel>> GET_RoomAll(int hotelId)
        {
            var dataReturn = await _roomRepository.GET_Room(null, null, null, hotelId, null);
            if (dataReturn == null) throw new Exception(MsgErro.ErroConsultaBancoDados);

            return _mapper.Map<IEnumerable<RoomViewModel>>(dataReturn);
        }

        public async Task<RoomViewModel> SET_Room(RoomViewModel roomViewModel)
        {
            if (roomViewModel == null) throw new Exception(MsgErro.ErroCadastroBancoDados);
            if (roomViewModel.RoomNumber == null ||
                roomViewModel.Floor == null ||
                roomViewModel.HotelID == null ||
                roomViewModel.HotelID <= 0 ) throw new Exception("Preencha todos os campos");
           
            var dataReturnGet = await _roomRepository.GET_Room(null, roomViewModel.RoomNumber, roomViewModel.Floor, roomViewModel.HotelID, true);
            if (dataReturnGet != null && dataReturnGet.Count() > 1) throw new Exception("Quarto já existe");

            var dataReturn = await _roomRepository.SET_Room((int)roomViewModel.RoomNumber, (int)roomViewModel.Floor, (int)roomViewModel.HotelID);
            return _mapper.Map<RoomViewModel>(dataReturn);
        }
        public async Task<RoomViewModel> Modify_Status_Room(int idRoom)
        {
            if (idRoom <= 0) throw new Exception(MsgErro.ErroCadastroBancoDados);
            var dataReturn = await _roomRepository.Modify_Status_Room(idRoom);
            if (dataReturn == null) throw new Exception(MsgErro.ErroEdicaoBancoDados);
            return _mapper.Map<RoomViewModel>(dataReturn);
        }

        public async Task<RoomReserveViewModel> ReserveRoom(int idRoom, int userID, DateTime dtInit, DateTime dtEnd)
        {
            var roomExist = await _roomRepository.GET_Room(idRoom, null, null, null, false);
            if(roomExist == null) throw new Exception("Quarto Selecionado não está disponível");
            if(userID <= 0) throw new Exception("Usuário Selecionado não está disponível");
            if(dtInit > dtEnd) throw new Exception("Selecione a data de inicio menor que a data de fim da reserva");
            var dataReturn = await _roomRepository.ReserveRoom(idRoom, userID,dtInit,dtEnd);

            return _mapper.Map<RoomReserveViewModel>(dataReturn);
        }

    }
}
