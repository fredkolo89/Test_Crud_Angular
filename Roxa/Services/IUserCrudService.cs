using Microsoft.AspNetCore.Identity;
using Roxa.BLL;
using Roxa.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roxa.Services
{
    public interface IUserCrudService
    {
        string GenerateJwtToken(User user, List<Role> roles);

        Task<IList<UserBll>> GetLists();

    }
}
