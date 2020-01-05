using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AndroidApi.Domain.DTO_s;
using AndroidApi.Domain.DTOs;
using AndroidApi.Domain.IRepositories;
using AndroidApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AndroidApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class TaskController : ControllerBase
    {

        private readonly ITaskRepository _tasks;
        private readonly IUserRepository _users;

        public TaskController(ITaskRepository tasks, IUserRepository users)
        {
            _tasks = tasks;
            _users = users;
        }

        /// <summary>
        ///Change the label for the task with given id
        /// </summary>
        /// <param name="taskId">the id of the task/param>
        /// <returns>The task</returns>
        [HttpPut("label/{taskId}")]
        public ActionResult<TaskDTO> ChangeLabel(long taskId)
        {
            try
            {

                ToDoTask task = _tasks.GetById(taskId);

                task.IsCompleted = task.IsCompleted!;
                _tasks.SaveChanges();

                TaskDTO dto =  new TaskDTO(task);
                if(dto.ResponsibleId > 0)
                {
                    dto.ResponsibleUser = new UserDTO(_users.GetById(dto.ResponsibleId));
                }
                
                return dto;
            }
            catch (ArgumentNullException)
            {
                return NotFound("Task niet gevonden");
            }

        }
        /// <summary>
        ///Change the user responsible for the task with given id
        /// </summary>
        /// <param name="taskId">the id of the task/param>
        /// <param name="userId">the id of the user/param>
        /// <returns>The task</returns>
        [HttpPut("user/{taskId}/{userId}")]
        public ActionResult<TaskDTO> ChangeUser(long taskId, long userId)
        {
            try
            {

                ToDoTask task = _tasks.GetById(taskId);

                task.ResponsibleId = userId;
                _tasks.SaveChanges();

                TaskDTO dto = new TaskDTO(task);
                if (dto.ResponsibleId > 0)
                {
                    dto.ResponsibleUser = new UserDTO(_users.GetById(dto.ResponsibleId));
                }

                return dto;
            }
            catch (ArgumentNullException)
            {
                return NotFound("Task niet gevonden");
            }

        }
    }
}