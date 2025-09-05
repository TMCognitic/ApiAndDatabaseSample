using BStorm.Tools.CommandQuerySeparation.Commands;

namespace ApiAndDatabaseSample.Api.Models.Commands
{
    public class DeleteTaskCommand(int id)
        : ICommandDefinition
    {
        public int Id { get; } = id;
    }
}
