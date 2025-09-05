namespace ApiAndDatabaseSample.Api.Models.Entities
{
    public class Todo(int id, string title, bool done)
    {
        public int Id { get; } = id;
        public string Title { get; } = title;
        public bool Done { get; } = done;
    }
}
