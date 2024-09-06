## About Project

The primary goal of this project was to practice using Entity Framework Core and explore its core functionalities, including data modeling, relationships, migrations, and the repository pattern.

## Model Relationships

- **CourseEntity**: Represents a course and has a one-to-many relationship with `LessonEntity` and a many-to-one relationship with `AuthorEntity`.
- **LessonEntity**: Represents a lesson that belongs to a specific course.
- **AuthorEntity**: Represents the author of a course.
- **StudentEntity**: Represents students enrolled in courses.

## Database Configuration

The `AppDbContext` class is configured to manage the following entities:

- `Courses`
- `Lessons`
- `Authors`
- `Students`

### Model Configuration

Each entity is configured in separate configuration classes (e.g., `CourseConfiguration`, `LessonConfiguration`, etc.) to ensure a clean separation of concerns. The `OnModelCreating` method in `AppDbContext` applies these configurations.


## Repositories

The project implements the repository pattern for data access, encapsulating the logic for interacting with the database. The main repositories include:

### CourseRepository

- **Get**: Retrieve all courses.
- **GetWithLessons**: Retrieve all courses along with their lessons.
- **GetById**: Retrieve a course by its ID.
- **GetByFilter**: Retrieve courses filtered by title and price.
- **GetByPage**: Retrieve courses with pagination support.
- **Add**: Add a new course.
- **Update**: Update an existing course.
- **Delete**: Remove a course.

### LessonsRepository

- **AddLesson**: Add a lesson to a specific course.
- **AddLesson2**: Add a lesson with a title directly.
