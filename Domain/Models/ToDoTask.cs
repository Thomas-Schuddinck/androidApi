using AndroidApi.Domain.DTOs;
using AndroidApi.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Domain.Models
{
    public class ToDoTask
    {
         
        public long TaskId { get; set; }

        public string TaskName { get; set; }
        public string Description { get; set; }
        public TaskLabel TaskLabel { get; set; }
        public long ResponsibleId { get; set; }
        public Boolean IsCompleted { get; set; }


        public ToDoTask()
        {
        }

        public ToDoTask(TaskDTO t)
        {
            TaskName = t.TaskName;
            Description = t.Description;
            TaskLabel = t.TaskLabel;
            IsCompleted = t.IsCompleted;
            if(t.ResponsibleId > 0)
            {
                ResponsibleId = t.ResponsibleId;
            }
            
        }
        public void Finish()
        {
            IsCompleted = true;
        }

    }
}
