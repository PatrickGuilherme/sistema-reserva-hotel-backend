using Application.IService;
using Application.ViewModel;
using AutoMapper;
using Domain.Model;
using Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) throw new Exception("Preencha todos os campos");

            var dataReturn = await _userRepository.Login(email, password);
            return _mapper.Map<UserViewModel>(dataReturn);
        }

    }
}
