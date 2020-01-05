using AndroidApi.Domain;
using AndroidApi.Domain.IRepositories;
using AndroidApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            _users = context.users;
        }

        public void Add(User obj)
        {
            _users.Add(obj);
        }

        public ICollection<User> GetAll()
        {
            throw new NotImplementedException();
        }

       

        public User GetById(long id)
        {
            return _users
                .Include(t => t.TaskTeamUsers).ThenInclude(t => t.TaskTeam)
                .SingleOrDefault(u => u.UserId == id);
        }

        public User GetUserByMail(string email)
        {
            return _users
                .SingleOrDefault(u => u.Email.ToUpper().Equals(email.ToUpper()));
        }

        public void Remove(User obj)
        {
            _users.Remove(obj);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
