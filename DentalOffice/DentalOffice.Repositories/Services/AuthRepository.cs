using AutoMapper;
using DentalOffice.Dtos;
using DentalOffice.Entities.dbContext;
using DentalOffice.Entities.dbEntities;
using DentalOffice.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DentalOffice.Repositories.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AuthRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        private static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public async Task<UserDto> Authenticate(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user != null)
            {
                var newHash = GenerateHash(user.PasswordSalt, password);
                if (newHash == user.PasswordHash)
                {
                    return _mapper.Map<UserDto>(user);
                }
            }
            return null;
        }

        public async Task<UserDto> Login(UserLoginDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.Username);

            if (user is null)
                return null;

            var hash = GenerateHash(user.PasswordSalt, request.Password);

            if (!hash.Equals(user.PasswordHash))
                return null;

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> Register(UserDto request)
        {
            if (request.Password != request.PasswordConfirm)
            {
                throw new Exception("Password and password confirm are not same!");
            }

            var entity = _mapper.Map<User>(request);

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(entity);
        }
    }
}
