using AndroidApi.Domain.DTOs;
using AndroidApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Domain.DTO_s
{
    public class TaskTeamDTO
    {
        public long TeamId { get; set; }

        public string TeamName { get; set; }
        public string Description { get; set; }
        public long OwnerId { get; set; }
        public ICollection<TaskDTO> Tasks { get; set; }

        public ICollection<UserDTO> Users { get; set; } = new List<UserDTO>();

        public TaskTeamDTO()
        {
        }

        public TaskTeamDTO(TaskTeam taskTeam)
        {
            TeamId = taskTeam.TeamId;
            TeamName = taskTeam.TeamName;
            Description = taskTeam.Description;
            OwnerId = taskTeam.OwnerId;
            Tasks = taskTeam.Tasks.Select(t => new TaskDTO(t)).ToList();
        }
    }
}
