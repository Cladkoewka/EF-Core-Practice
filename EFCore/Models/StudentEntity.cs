namespace EFCore.Models;

public class StudentEntity
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public Guid CourseId { get; set; }
    public List<CourseEntity> Courses { get; set; } = [];
}