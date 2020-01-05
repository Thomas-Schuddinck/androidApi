using AndroidApi.Domain;
using AndroidApi.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Data.Repositories
{
    public class TaskTeamRepository : ITaskTeamRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TaskTeam> _taskTeams;

        public TaskTeamRepository(ApplicationDbContext context)
        {
            _context = context;
            _taskTeams = context.taskTeams;
        }

        public void Add(TaskTeam obj)
        {
            _taskTeams.Add(obj);
        }

        public ICollection<TaskTeam> GetAll()
        {
            return _taskTeams
                .Include(t => t.Tasks)
                .Include(t => t.TaskTeamUsers).ThenInclude(t => t.TaskTeam)
                .ToList();
        }

        public TaskTeam GetById(long id)
        {
            return _taskTeams
                .Include(t => t.Tasks)
                .SingleOrDefault(t => t.TeamId == id);
        }

        public TaskTeam GetByIdSimple(long teamId)
        {
            return _taskTeams
                .Include(t => t.TaskTeamUsers).ThenInclude(t => t.TaskTeam)
                .SingleOrDefault(t => t.TeamId == teamId);
        }


        public TaskTeam GetByTeamCodeSimple(string teamcode)
        {
            return _taskTeams
                .Include(t => t.TaskTeamUsers).ThenInclude(t => t.TaskTeam)
                .SingleOrDefault(t => t.UniqueTeamCode == teamcode);
        }

        public ICollection<TaskTeam> GetAllTeamsFromUserWithId(long userId)
        {
            return _taskTeams
                .Include(t => t.Tasks)
                /*.Include(t => t.TaskTeamUsers).ThenInclude(t => t.TaskTeam)
                .Include(t => t.TaskTeamUsers).ThenInclude(t => t.User)
                */
                .Where(t => t.TaskTeamUsers.Any(u => u.UserId == userId) || t.OwnerId == userId)
                .ToList();
        }

        public TaskTeam GetByUniqueTaskTeamCodeWithTasks(string uniqueTeamCode)
        {
            return _taskTeams
                .Include(t => t.Tasks)
                .SingleOrDefault(t => t.UniqueTeamCode == uniqueTeamCode);
        }

        public TaskTeam GetByUniqueTaskTeamCodeWithUsersAndTasks(string uniqueTeamCode)
        {
            return _taskTeams
                .Include(t => t.Tasks)
                .Include(t => t.TaskTeamUsers).ThenInclude(t => t.TaskTeam)
                .SingleOrDefault(t => t.UniqueTeamCode == uniqueTeamCode);
        }

        public void Remove(TaskTeam obj)
        {
            _taskTeams.Remove(obj);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
