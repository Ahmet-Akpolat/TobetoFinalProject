using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Course : Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<CourseContent>? GetCourseContents { get; set; }
    public virtual ICollection<LectureCourse>? GetLectureCourses { get; set; }
}


