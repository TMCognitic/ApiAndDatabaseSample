using ApiAndDatabaseSample.Api.Models.Entities;
using BStorm.Tools.CommandQuerySeparation.Queries;

namespace ApiAndDatabaseSample.Api.Models.Queries
{
    public class GetTasksQuery 
        : IQueryDefinition<IEnumerable<Todo>>
    {
    }
}
