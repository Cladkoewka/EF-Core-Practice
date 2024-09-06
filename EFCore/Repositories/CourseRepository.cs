using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repositories;

public class CourseRepository
{
    private readonly AppDbContext _dbContext;

    public CourseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CourseEntity>> Get()
    {
        return await _dbContext.Courses
            .AsNoTracking()
            .OrderBy(c => c.Title)
            .ToListAsync();
    }
    public async Task<List<CourseEntity>> GetWithLessons()
    {
        return await _dbContext.Courses
            .AsNoTracking()
            .Include(c => c.Lessons)
            .ToListAsync();
    }
    public async Task<CourseEntity?> GetById(Guid id)
    {
        return await _dbContext.Courses
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<List<CourseEntity>> GetByFilter(string title, decimal price)
    {
        var query = _dbContext.Courses.AsNoTracking();

        if (!string.IsNullOrEmpty(title))
        {
            query = query.Where(c => c.Title.Contains(title));
        }

        if (price > 0)
        {
            query = query.Where(c => c.Price > price);
        }

        return await query.ToListAsync();
    }

    public async Task<List<CourseEntity>> GetByPage(int page, int pageSize)
    {
        return await _dbContext.Courses
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task Add(Guid id, Guid authorid, string title, string description, decimal price)
    {
        var courseEntity = new CourseEntity
        {
            Id = id,
            AuthorId = authorid,
            Title = title,
            Description = description,
            Price = price
        };

        await _dbContext.AddAsync(courseEntity);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task Update(Guid id, Guid authorid, string title, string description, decimal price)
    {
        var courseEntity = _dbContext.Courses.FirstOrDefault(c => c.Id == id) ?? throw new Exception();

        courseEntity.Title = title;
        courseEntity.Price = price;
        courseEntity.Description = description;

        await _dbContext.SaveChangesAsync();
    }
    
    public async Task Update2(Guid id, Guid authorid, string title, string description, decimal price)
    {
        var courseEntity = _dbContext.Courses
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Title, title)
                .SetProperty(c => c.Description, description)
                .SetProperty(c => c.Price, price));

        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        await _dbContext.Courses
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }
}

public class LessonsRepository
{
    private readonly AppDbContext _dbContext;

    public LessonsRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task AddLesson(Guid courseId, LessonEntity lesson)
    {
        var course = await _dbContext.Courses.FirstOrDefaultAsync(c => c.Id == courseId) ?? throw new Exception();
        course.Lessons.Add(lesson);
    }
    
    public async Task AddLesson2(Guid courseId, string title)
    {
        var lesson = new LessonEntity
        {
            Title = title,
            CourseId = courseId
        };
        await _dbContext.AddAsync(lesson);
        await _dbContext.SaveChangesAsync();
    }
}