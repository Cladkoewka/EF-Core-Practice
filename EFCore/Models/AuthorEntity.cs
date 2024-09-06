namespace EFCore.Models;

public class AuthorEntity
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public Guid CourseId { get; set; }
    public CourseEntity? Course { get; set; }
}