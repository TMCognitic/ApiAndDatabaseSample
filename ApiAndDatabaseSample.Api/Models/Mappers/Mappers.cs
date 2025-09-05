using ApiAndDatabaseSample.Api.Models.Entities;
using System.Data;

namespace ApiAndDatabaseSample.Api.Models.Mappers
{
    internal static class Mappers
    {
        internal static Todo ToTodo(this IDataRecord record)
        {
            return new Todo((int)record["Id"], (string)record["Title"], (bool)record["Done"]);
        }
    }
}
