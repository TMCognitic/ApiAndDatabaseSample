using BStorm.Tools.CommandQuerySeparation.Commands;

namespace ApiAndDatabaseSample.Api.Models.Commands
{
    public class CreateTodoCommand(string title)
        : ICommandDefinition
    {
        public string Title { get; } = title;
    }
}
