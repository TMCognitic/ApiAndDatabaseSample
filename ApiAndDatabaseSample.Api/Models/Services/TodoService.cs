using ApiAndDatabaseSample.Api.Models.Commands;
using ApiAndDatabaseSample.Api.Models.Entities;
using ApiAndDatabaseSample.Api.Models.Mappers;
using ApiAndDatabaseSample.Api.Models.Queries;
using ApiAndDatabaseSample.Api.Models.Repositories;
using BStorm.Tools.CommandQuerySeparation.Results;
using BStorm.Tools.Database;
using System.Data.Common;

namespace ApiAndDatabaseSample.Api.Models.Services
{
    public class TodoService(DbConnection _dbConnection)
        : ITodoRepository
    {
        public ICqsResult<IEnumerable<Todo>> Execute(GetTasksQuery query)
        {
            try
            {
                _dbConnection.Open();
                IEnumerable<Todo> result = _dbConnection.ExecuteReader("SELECT Id, Title, Done FROM Todo;", r => r.ToTodo()).ToList();
                return ICqsResult<IEnumerable<Todo>>.Success(result);
            }
            catch (Exception ex)
            {
                return ICqsResult<IEnumerable<Todo>>.Failure(ex.Message, ex);
            }
        }

        public ICqsResult Execute(CreateTodoCommand command)
        {
            try
            {
                _dbConnection.Open();
                _dbConnection.ExecuteNonQuery("INSERT INTO Todo (Title) VALUES (@Title);", parameters:command);
                return ICqsResult.Success();
            }
            catch (Exception ex)
            {
                return ICqsResult.Failure(ex.Message, ex);
            }
        }

        public ICqsResult Execute(ChangeStateCommand command)
        {
            try
            {
                _dbConnection.Open();
                int rows = _dbConnection.ExecuteNonQuery("UPDATE Todo SET Done = (CASE Done WHEN 0 THEN 1 ELSE 0 END) WHERE Id = @Id;", parameters: command);

                if(rows == 0)
                {
                    return ICqsResult.Failure("Not found");
                }
                return ICqsResult.Success();
            }
            catch (Exception ex)
            {
                return ICqsResult.Failure(ex.Message, ex);
            }
        }

        public ICqsResult Execute(DeleteTaskCommand command)
        {
            try
            {
                _dbConnection.Open();
                int rows = _dbConnection.ExecuteNonQuery("DELETE FROM Todo WHERE Id = @Id;", parameters: command);
                if (rows == 0)
                {
                    return ICqsResult.Failure("Not found");
                }
                return ICqsResult.Success();
            }
            catch (Exception ex)
            {
                return ICqsResult.Failure(ex.Message, ex);
            }
        }
    }
}
