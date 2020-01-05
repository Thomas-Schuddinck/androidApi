using AndroidApi.Domain.DTO_s;
using AndroidApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Domain
{
    public class TaskTeam
    {
        public long TeamId { get; set; }

        public string TeamName { get; set; }
        public string Description { get; set; }
        public long OwnerId { get; set; }
        public ICollection<ToDoTask> Tasks { get; set; }

        public ICollection<TaskTeamUser> TaskTeamUsers { get; set; } = new List<TaskTeamUser>();
        public string TeamCode { get; set; }
        public string UniqueTeamCode => TeamCode + DateTime.Today.Date.Month.ToString() + TeamId.ToString() + DateTime.Today.Date.Year.ToString();

        public TaskTeam()
        {
            Tasks = new List<ToDoTask>();
            TaskTeamUsers = new List<TaskTeamUser>();
        }

        public TaskTeam(TaskTeamDTO dto)
        {
            Tasks = new List<ToDoTask>();
            TaskTeamUsers = new List<TaskTeamUser>();
            TeamName = dto.TeamName;
            OwnerId = dto.OwnerId;
            Description = dto.Description;
            if (dto.Tasks != null)
            {
                dto.Tasks.ToList().ForEach(t => AddTask(new ToDoTask(t)));
            }
            if(dto.Users != null)
            {
                dto.Users.ToList().ForEach(u => AddUser(new User(u)));
            }
            TeamCode = DateTime.Today.Millisecond.ToString() + Guid.NewGuid().ToString().Substring(0, 4) + DateTime.Today.Millisecond.ToString();
        }

        public void AddTask(ToDoTask toDoTask)
        {
            Tasks.Add(toDoTask);
        }
        public void RemoveTask(ToDoTask toDoTask)
        {
            Tasks.Remove(toDoTask);
        }

        public void AddUser(User u)
        {
            TaskTeamUsers.Add(new TaskTeamUser
            {
                TaskTeam = this,
                UserId = u.UserId
            });

        }
        public void RemoveUser(TaskTeamUser ttu)
        {
            TaskTeamUsers.Remove(ttu);
        }
    }
}
