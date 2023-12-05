using Magic_Villa_VillaApi.Data;
using Magic_Villa_VillaApi.Models;
using Magic_Villa_VillaApi.Models.UserDTO;
using Magic_Villa_VillaApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace Magic_Villa_VillaApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _Db;
        private string SecretKey;
        public UserRepository(ApplicationDbContext context, IConfiguration configuration) 
        { 
            _Db = context;
            SecretKey = configuration.GetValue<string>("ApiSettings:Secret");
        
        }
        public bool IsUniqueUser(string userName)
        {
            var user = _Db.LocalUsers.FirstOrDefault(x => x.UserName == userName);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _Db.LocalUsers.FirstOrDefaultAsync(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower() 
                                                                && u.Password == loginRequestDto.Password);
            if (user == null)
            {
                return new LoginResponseDto()
                {
                    Token = "",
                    user = null
                }; 
            }
            // if user was found generate token
            var TokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var TokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = TokenHandler.CreateToken(TokenDescriptor);
            LoginResponseDto responseDto = new LoginResponseDto()
            {
                user = user,
                Token = TokenHandler.WriteToken(token)
            };
            return responseDto;
        }

        public async Task<Users> Register(RegistrationRequestDto registrationRequestDto)
        {
            var isuniqu = IsUniqueUser(registrationRequestDto.UserName);
            if (isuniqu)
            {
                Users user = new Users() { 
                    UserName = registrationRequestDto.UserName,
                    Name = registrationRequestDto.Name,
                    Password = registrationRequestDto.Password,
                    Role = registrationRequestDto.Role
                };
                await _Db.LocalUsers.AddAsync(user);
                await _Db.SaveChangesAsync();
                user.Password = "";
                return user;
            }
            return null;
        }
    }
}
