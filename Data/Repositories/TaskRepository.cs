using AndroidApi.Domain.IRepositories;
using AndroidApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<ToDoTask> _tasks;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
            _tasks = context.tasks;
        }

        public void Add(ToDoTask obj)
        {
            _tasks.Add(obj);
        }

        public ICollection<ToDoTask> GetAll()
        {
            throw new NotImplementedException();
        }

        public ToDoTask GetById(long id)
        {
            return _tasks.SingleOrDefault(t => t.TaskId == id);
    }

        public void Remove(ToDoTask obj)
        {
            _tasks.Remove(obj);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
