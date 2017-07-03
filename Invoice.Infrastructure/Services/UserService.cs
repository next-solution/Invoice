using System;
using System.Threading.Tasks;
using AutoMapper;
using Invoice.Core.Domain;
using Invoice.Core.Repositories;
using Invoice.Infrastructure.DTO;

namespace Invoice.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;
        
        public UserService(IUserRepository userRepository, IEncrypter encrypter, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _encrypter = encrypter;
        }
        public async Task<UserDto> GetAsync(string username)
        {
            var user = await _userRepository.GetAsync(username);
            
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetAsync(username);

            if (user == null)
            {
                throw new Exception ("Invalid credentials.");
            }

            if (user.Password == _encrypter.GetHash(password, user.Salt))
            {
                return;
            }
            throw new Exception ("Invalid credentials.");
                
        }

        public async Task RegisterAsync(string username, string password, string fullname)
        {
            var user = await _userRepository.GetAsync(username);

            if(user != null)
            {
                throw new Exception ($"User: '{username}' already exists.");
            }

            var salt = _encrypter.GetSalt();
            user = new User(username, _encrypter.GetHash(password, salt), salt, fullname);
            await _userRepository.AddAsync(user);
        }
    }
}