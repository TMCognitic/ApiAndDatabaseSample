using ApiAndDatabaseSample.Api.Models.Commands;
using ApiAndDatabaseSample.Api.Models.Dtos;
using ApiAndDatabaseSample.Api.Models.Entities;
using ApiAndDatabaseSample.Api.Models.Queries;
using ApiAndDatabaseSample.Api.Models.Repositories;
using BStorm.Tools.CommandQuerySeparation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ApiAndDatabaseSample.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController (ILogger<TodoController> _logger, ITodoRepository _todoRepository)
        : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation($"Request [{Request.Method}] on {Request.Path}");

            ICqsResult<IEnumerable<Todo>> result = _todoRepository.Execute(new GetTasksQuery());

            if (result.IsFailure)
                return BadRequest(new { Message = result.ErrorMessage });

            return Ok(result.Content);
        }

        [HttpPost]
        public IActionResult Post(CreateTodoDto dto)
        {
            _logger.LogInformation($"Request [{Request.Method}] on {Request.Path}");
            ICqsResult result = _todoRepository.Execute(new CreateTodoCommand(dto.Title));

            if (result.IsFailure)
                return BadRequest(new { Message = result.ErrorMessage });

            return NoContent();
        }

        [HttpPatch("ChangeState/{id}")]
        public IActionResult Put(int id)
        {
            _logger.LogInformation($"Request [{Request.Method}] on {Request.Path}");
            ICqsResult result = _todoRepository.Execute(new ChangeStateCommand(id));

            if (result.IsFailure)
                return BadRequest(new { Message = result.ErrorMessage });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"Request [{Request.Method}] on {Request.Path}");
            ICqsResult result = _todoRepository.Execute(new DeleteTaskCommand(id));

            if (result.IsFailure)
                return BadRequest(new { Message = result.ErrorMessage });

            return NoContent();
        }
    }
}
