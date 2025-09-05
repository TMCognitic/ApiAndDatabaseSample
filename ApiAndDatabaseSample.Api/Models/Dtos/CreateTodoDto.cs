using System.ComponentModel.DataAnnotations;

namespace ApiAndDatabaseSample.Api.Models.Dtos
{
    public class CreateTodoDto(string title)
    {
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Title { get; } = title;
    }
}
