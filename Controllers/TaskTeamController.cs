using AndroidApi.Domain;
using AndroidApi.Domain.DTO_s;
using AndroidApi.Domain.DTOs;
using AndroidApi.Domain.IRepositories;
using AndroidApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class TaskTeamController : ControllerBase
    {
        private readonly ITaskTeamRepository _taskTeams;
        private readonly IUserRepository _users;
        private readonly ITaskRepository _tasks;

        public TaskTeamController(IUserRepository users,
            ITaskTeamRepository taskTeams,
            ITaskRepository tasks)
        {
            _taskTeams = taskTeams;
            _users = users;
            _tasks = tasks;
        }

        /// <summary>
        /// Get the taskteam for a given id
        /// </summary>
        /// <param name="teamId">the id of the taskteam</param>
        /// <returns>The taskteam</returns>
        [HttpGet("{teamId}")]
        public ActionResult<TaskTeamDTO> GetTaskTeam(long teamId)
        {
            try
            {
                TaskTeam team = _taskTeams.GetById(teamId);
                TaskTeamDTO dto =  new TaskTeamDTO(team);
                dto.Tasks.ToList().ForEach(t => t.ResponsibleUser = new UserDTO(_users.GetById(t.ResponsibleId)));
                team.TaskTeamUsers.ToList().ForEach(ttu => dto.Users.Add(new UserDTO(_users.GetById(ttu.UserId))));
                return dto;
            }
            catch (ArgumentNullException)
            {
                return NotFound("Taskteam niet gevonden");
            }

        }

        /// <summary>
        /// Get all the taskteams from user with given id
        /// </summary>
        /// <param name="userId">the id of the user</param>
        /// <returns>The taskteams</returns>
        [HttpGet("fromUser/{userId}")]
        public ActionResult<ICollection<TaskTeamDTO>> GetTaskTeamsFromUser(long userId)
        {
            try
            {
                ICollection<TaskTeam> teams = _taskTeams.GetAllTeamsFromUserWithId(userId);
                List<TaskTeamDTO> result = new List<TaskTeamDTO>();
                foreach(TaskTeam team in teams)
                {
                    TaskTeamDTO dto = new TaskTeamDTO(team);
                    dto.Tasks.ToList().ForEach(t => t.ResponsibleUser = new UserDTO(_users.GetById(t.ResponsibleId)));
                    team.TaskTeamUsers.ToList().ForEach(ttu => dto.Users.Add(new UserDTO(_users.GetById(ttu.UserId))));
                    result.Add(dto);
                }

                return result;
            }
            catch (ArgumentNullException)
            {
                return NotFound("Taskteam niet gevonden");
            }

        }

        /// <summary>
        /// Get the taskteam for a given teamCode with its users and tasks
        /// </summary>
        /// <param name="teamCode">the code of the taskteam</param>
        /// <returns>The taskteam with its users and tasks</returns>
        [HttpGet("teamCode/{teamCode}")]
        public ActionResult<TaskTeamDTO> GetTaskTeamFromCode(string teamCode)
        {
            try
            {
                TaskTeam team = _taskTeams.GetByUniqueTaskTeamCodeWithUsersAndTasks(teamCode);
                TaskTeamDTO dto = new TaskTeamDTO(team);
                dto.Tasks.ToList().ForEach(t => t.ResponsibleUser = new UserDTO(_users.GetById(t.ResponsibleId)));
                team.TaskTeamUsers.ToList().ForEach(ttu => dto.Users.Add(new UserDTO(_users.GetById(ttu.UserId))));
                return dto;
            }
            catch (ArgumentNullException)
            {
                return NotFound("Groep niet gevonden");
            }

        }

        /// <summary>
        /// Add a new taskteam
        /// </summary>
        /// <param name="dto">the taskteam to be added</param>
        /// <returns>The taskteam</returns>
        [HttpPost]
        public ActionResult<TaskTeamDTO> AddTaskTeam([FromBody] TaskTeamDTO dto)
        {
            try
            {

                TaskTeam taskTeam = new TaskTeam(dto);
                
                _taskTeams.Add(taskTeam);
                _taskTeams.SaveChanges();

                TaskTeam team = _taskTeams.GetAll().OrderByDescending(t => t.TeamId).FirstOrDefault();
                TaskTeamDTO dtor = new TaskTeamDTO(team);
                //dtor.Tasks.ToList().ForEach(t => t.ResponsibleUser = new UserDTO(_users.GetById(t.ResponsibleId)));
                //team.TaskTeamUsers.ToList().ForEach(ttu => dtor.Users.Add(new UserDTO(_users.GetById(ttu.UserId))));
                return dtor;
            }
            catch (ArgumentNullException)
            {
                return NotFound("Taskteam niet gevonden");
            }

        }

        
        /// <summary>
        /// Remove a taskteam
        /// </summary>
        /// <param name="teamId">The team to remove</param>
        /// <returns>The removed taskTeam</returns>
        [HttpDelete("{teamId}")]
        public ActionResult<TaskTeamDTO> RemoveTeam(long teamId)
        {
            try
            {
                TaskTeam tt = _taskTeams.GetByIdSimple(teamId);
                _taskTeams.Remove(tt);
                _taskTeams.SaveChanges();

                return new TaskTeamDTO(tt);
            }
            catch (ArgumentNullException)
            {
                return NotFound("Team or user not found");
            }
        }


        /// <summary>
        /// Adds a user to a taskteam
        /// </summary>
        /// <param name="userId">The user to add</param>
        /// <param name="teamCode">the code of the team</param>
        /// <returns>The added user</returns>
        [HttpPost("addUser/{teamCode}/{userId}")]
        public ActionResult<UserDTO> AddUser(long userId, String teamCode)
        {
            try
            {
                TaskTeam tt = _taskTeams.GetByTeamCodeSimple(teamCode);
                User u = _users.GetById(userId);

                tt.AddUser(u);
                _taskTeams.SaveChanges();

                return new UserDTO(u);
            }
            catch (ArgumentNullException)
            {
                return NotFound("Team or user not found");
            }
        }

        /// <summary>
        /// Remove a user from a taskteam
        /// </summary>
        /// <param name="userId">The user to remove</param>
        /// <param name="teamCode">the code of the team</param>
        /// <returns>The removed user</returns>
        [HttpPost("removeUser/{teamCode}/{userId}")]
        public ActionResult<UserDTO> RemoveUser(long userId, String teamCode)
        {
            try
            {
                TaskTeam tt = _taskTeams.GetByTeamCodeSimple(teamCode);
                User u = _users.GetById(userId);
                tt.RemoveUser(tt.TaskTeamUsers.Where(ttu => (ttu.TaskTeamId == tt.TeamId && ttu.UserId == u.UserId)).FirstOrDefault());
                _taskTeams.SaveChanges();

                return new UserDTO(u);
            }
            catch (ArgumentNullException)
            {
                return NotFound("Team or user not found");
            }
        }

        /// <summary>
        /// updates a taskteam
        /// </summary>
        /// <param name="taskTeamId">id of the taskteam to be modified</param>
        /// <param name="dto">the modified taskteam</param>
        [HttpPut("{taskTeamId}")]
        public ActionResult<TaskTeamDTO> Put([FromBody] TaskTeamDTO dto, long taskTeamId)
        {
            try
            {
                var tt = _taskTeams.GetById(taskTeamId);

                tt.TeamName = dto.TeamName;
                tt.Description = dto.Description;
                UpdateTasks(taskTeamId, dto.Tasks);
                UpdateTaskTeamUsers(taskTeamId, dto.Users);

                _taskTeams.SaveChanges();
                return new TaskTeamDTO(tt);
            }
            catch (ArgumentNullException)
            {
                return NotFound("Team niet gevonden");
            }

        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public void UpdateTaskTeamUsers(long id, ICollection<UserDTO> users)
        {
            var taskteam = _taskTeams.GetById(id);
            taskteam.TaskTeamUsers.Clear();
            users.ToList().ForEach(u => taskteam.AddUser(_users.GetById(u.UserId)));
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public void UpdateTasks(long id, ICollection<TaskDTO> tasks)
        {
            var taskteam = _taskTeams.GetById(id);
            foreach (var item in taskteam.Tasks.ToList())
            {
                var taskMatch = tasks.FirstOrDefault(t => t.TaskId == item.TaskId);
                if (taskMatch == null) // the task has been removed by the user
                {
                    taskteam.RemoveTask(item);
                }
                else // the task is still present in both arrays so update the task
                {
                    item.TaskName = taskMatch.TaskName;
                    item.Description = taskMatch.Description;
                    item.IsCompleted = taskMatch.IsCompleted;
                    item.TaskLabel = taskMatch.TaskLabel;
                    item.ResponsibleId = taskMatch.ResponsibleId;
                    

                }
            }

            foreach (var item in tasks.ToList()) // adds tasks that have been added to this template
            {

                var taskTeamTaskMatch = taskteam.Tasks.FirstOrDefault(t => t.TaskId == item.TaskId);
                if (taskTeamTaskMatch == null) // the task is just added
                {

                    taskteam.AddTask(new ToDoTask(item));
                }

            }
        }


    }
}