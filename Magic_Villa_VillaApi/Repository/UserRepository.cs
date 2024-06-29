using AutoMapper;
using Magic_Villa_VillaApi.Data;
using Magic_Villa_VillaApi.Models;
using Magic_Villa_VillaApi.Models.UserDTO;
using Magic_Villa_VillaApi.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _usermanger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private string SecretKey;
        public UserRepository(ApplicationDbContext context, IConfiguration configuration,UserManager<ApplicationUser> userManager
            ,IMapper mapper,RoleManager<IdentityRole> roleManager) 
        { 
            _Db = context;
            SecretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _usermanger = userManager;
            _mapper = mapper;
            _roleManager = roleManager;    
        
        }
        public bool IsUniqueUser(string userName)
        {
            var user = _Db.AppUser.FirstOrDefault(x => x.UserName == userName);
            if (user == null)
            {
                return true; 
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _Db.AppUser.FirstOrDefaultAsync(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());
           
            bool isvaild = await _usermanger.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || isvaild == false)
            {
                return new LoginResponseDto()
                {
                    Token = "",
                    User = null
                }; 
            }
            // if user was found generate token
            var roles = await _usermanger.GetRolesAsync(user);
            var TokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var TokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault())

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = TokenHandler.CreateToken(TokenDescriptor);
            
            LoginResponseDto responseDto = new LoginResponseDto()
            {
                User = _mapper.Map<UserDto>(user),
                Token = TokenHandler.WriteToken(token)
               // Role = roles.FirstOrDefault(),
            };

           
            return responseDto; 
        }

        public async Task<UserDto> Register(RegistrationRequestDto registrationRequestDto)
        {
            var isuniqu = IsUniqueUser(registrationRequestDto.UserName);
            if (isuniqu) {
                ApplicationUser user = new() {
                    UserName = registrationRequestDto.UserName,
                    Email = registrationRequestDto.UserName,
                    NormalizedEmail = registrationRequestDto.UserName.ToUpper(),
                    Name = registrationRequestDto.Name
                };
                try
                {
                    var res = await _usermanger.CreateAsync(user, registrationRequestDto.Password);
                    if (res.Succeeded) {
                        if (!_roleManager.RoleExistsAsync(registrationRequestDto.Role).GetAwaiter().GetResult())
                        {
                            await _roleManager.CreateAsync(new IdentityRole(registrationRequestDto.Role));
                        }
                        await _usermanger.AddToRoleAsync(user,registrationRequestDto.Role);
                        var UserToReturn = _Db.AppUser.FirstOrDefault(u => u.UserName == registrationRequestDto.UserName);
                        return _mapper.Map<UserDto>(UserToReturn);

                    }
                } catch (Exception ex) { }

            }
            return new UserDto();
        }
    }
}
