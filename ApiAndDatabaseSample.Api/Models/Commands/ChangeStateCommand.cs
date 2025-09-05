using BStorm.Tools.CommandQuerySeparation.Commands;

namespace ApiAndDatabaseSample.Api.Models.Commands
{
    public class ChangeStateCommand(int id) 
        : ICommandDefinition
    {
        public int Id { get; } = id;
    }
}
