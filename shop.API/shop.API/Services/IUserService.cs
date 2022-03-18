using shop.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.API.Services
{
    public interface IUserService
    {
        User Validate(string email, string password);
    }
}
