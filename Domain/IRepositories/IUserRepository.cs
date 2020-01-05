using AndroidApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Domain.IRepositories
{
    public interface IUserRepository :IGenericRepository<User>
    {
        User GetUserByMail(string email);
    }
}
