using AndroidApi.Domain.DTO_s;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Domain.Models
{
    public class User : IdentityUser<long>
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<TaskTeamUser> TaskTeamUsers { get; set; } = new List<TaskTeamUser>();

        public User()
        {
            TaskTeamUsers = new List<TaskTeamUser>();
        }
        public User(UserDTO dto)
        {
            UserId = dto.UserId;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            Email = dto.Email;
        

        }
    }
}
