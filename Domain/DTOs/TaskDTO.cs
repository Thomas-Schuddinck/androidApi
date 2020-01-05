using AndroidApi.Domain.DTO_s;
using AndroidApi.Domain.Models;
using AndroidApi.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Domain.DTOs
{
    public class TaskDTO
    {
        public long TaskId { get; set; }

        public string TaskName { get; set; }
        public string Description { get; set; }
        public TaskLabel TaskLabel { get; set; }
        public long ResponsibleId { get; set; }
        public UserDTO ResponsibleUser { get; set; }
        public Boolean IsCompleted { get; set; }

        public TaskDTO()
        {
        }
        public TaskDTO(ToDoTask toDoTask)
        {
            TaskId = toDoTask.TaskId;
            TaskName = toDoTask.TaskName;
            Description = toDoTask.Description;
            TaskLabel = toDoTask.TaskLabel;
            ResponsibleId = toDoTask.ResponsibleId;
            IsCompleted = toDoTask.IsCompleted;
        }
    }
}
