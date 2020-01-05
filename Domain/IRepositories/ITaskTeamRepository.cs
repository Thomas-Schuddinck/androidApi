using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndroidApi.Domain.IRepositories
{
    public interface ITaskTeamRepository : IGenericRepository<TaskTeam>
    {
        TaskTeam GetByUniqueTaskTeamCodeWithTasks(string uniqueGroupCode);
        TaskTeam GetByUniqueTaskTeamCodeWithUsersAndTasks(string uniqueGroupCode);
        TaskTeam GetByIdSimple(long teamId);
        TaskTeam GetByTeamCodeSimple(String teamcode);
        ICollection<TaskTeam> GetAllTeamsFromUserWithId(long userId);
    }
}
