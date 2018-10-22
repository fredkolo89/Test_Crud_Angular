using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Roxa.BLL;
using Roxa.DAL;
using Roxa.IoC;
using Roxa.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Roxa.Services
{
    public class UserCrudService : IUserCrudService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserCrudService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public string GenerateJwtToken(User user, List<Role> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserName)
            };
            
    
            foreach (var userRole in roles)
            { 
                claims.Add(new Claim(ClaimTypes.Role, userRole.Name));

                //zrozumiec na przyszlosc

                //var role = await _roleManager.FindByNameAsync(userRole);
                //if (role != null)
                //{
                //    var roleClaims = await _roleManager.GetClaimsAsync(role);
                //    foreach (Claim roleClaim in roleClaims)
                //    {
                //        claims.Add(roleClaim);
                //    }
                //}
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IoCContainer.Configuration["JwtIssuerOptions:JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(IoCContainer.Configuration["JwtIssuerOptions:JwtExpireDays"]));

            var token = new JwtSecurityToken(
                IoCContainer.Configuration["JwtIssuerOptions:JwtIssuer"],
                IoCContainer.Configuration["JwtIssuerOptions:JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IList<UserBll>> GetLists()
        {
            IList<User> userList = (await _userRepository.GetAllAsync()).ToList();
            return _mapper.Map<IList<User>, IList<UserBll>>(userList);          
        }

        //public void SaveUser(UserBll userBll)
        //{
        //    User user = new User();

        //    _mapper.Map<User, UserBll>(user);

        //    _userRepository.SaveUser(user);
        //}



        //public UserBll GetUserById(long id)
        //{
        //    throw new NotImplementedException();
        //}

        //public int GetValue()
        //{
        //    return 2;
        //}



        //public async Task<int> AddUser()
        //{
        //    return await _baseRepositoryInterface.Add(
        //        new User
        //        {
        //            Age = 12,
        //            Name = "heniu"
        //        });

        //}
    }
}
