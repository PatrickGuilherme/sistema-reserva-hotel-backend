using Application.IService;
using Application.ViewModel;
using AutoMapper;
using Domain.Model;
using Domain.MsgErro;
using Persistence.IRepository;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class HotelService : IHotelService
    {
        public readonly IHotelRepository _hotelRepository;
        private readonly IMapper _mapper;
        private bool test;
        private Mock mock;

        public HotelService(bool _test)
        {
            test = _test;
            mock = new Mock();
        }


        public HotelService(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<HotelViewModel> SET_Hotel(HotelViewModel hotelViewModel)
        {
            if (hotelViewModel == null) throw new Exception(MsgErro.ErroCadastroBancoDados);
            if (!hotelViewModel.VerifyInputValid()) throw new Exception("Preencha todos os campos");

            var dataReturnGet = await _hotelRepository.GET_Hotel(0, "", "", hotelViewModel.CNPJ);
            if (dataReturnGet != null && dataReturnGet.Count() > 1) throw new Exception("Hotel já existe");

            var dataReturn = await _hotelRepository.SET_Hotel(hotelViewModel.Name, hotelViewModel.Descrition, hotelViewModel.CNPJ, hotelViewModel.CEP, hotelViewModel.Address);
            if(!test) return _mapper.Map<HotelViewModel>(dataReturn);
            return new HotelViewModel
            {
                Name = dataReturn.Name,
                Address = dataReturn.Address,
                CEP = dataReturn.CEP,
                CNPJ = dataReturn.CNPJ,
                Descrition = dataReturn.Descrition
            };
        }
    }
}
