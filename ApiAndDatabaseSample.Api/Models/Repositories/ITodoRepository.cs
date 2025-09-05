using ApiAndDatabaseSample.Api.Models.Commands;
using ApiAndDatabaseSample.Api.Models.Entities;
using ApiAndDatabaseSample.Api.Models.Queries;
using BStorm.Tools.CommandQuerySeparation.Commands;
using BStorm.Tools.CommandQuerySeparation.Queries;

namespace ApiAndDatabaseSample.Api.Models.Repositories
{
    public interface ITodoRepository :
        IQueryHandler<GetTasksQuery, IEnumerable<Todo>>,
        ICommandHandler<CreateTodoCommand>,
        ICommandHandler<ChangeStateCommand>,
        ICommandHandler<DeleteTaskCommand>
    {
    }
}
