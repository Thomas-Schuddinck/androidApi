using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Domain.Models
{
    public class TaskTeamUser
    {
        public long TaskTeamId { get; set; }
        public TaskTeam TaskTeam { get; set; }
        public long UserId { get; set; }

        public TaskTeamUser()
        {

        }
    }
}
