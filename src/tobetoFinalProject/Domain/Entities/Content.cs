using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Content : Entity<Guid>
{
    public string Name { get; set; }
    public Guid LanguageId { get; set; }
    public string VideoUrl { get; set; }
    public string Description { get; set; }
    public string SubType { get; set; }
    public Guid ManufacturerId { get; set; }
    public DateTime Duration { get; set; }
    public Guid? ContentCategoryId { get; set; }
    public virtual Language? Language { get; set; }
    public virtual ContentCategory? ContentCategory { get; set; }
    public virtual ICollection<ContentInstructor>? GetContentInstructors { get; set; }
    public virtual ICollection<CourseContent>? GetCourseContents { get; set; }
    public virtual Manufacturer? Manufacturer { get; set; }
}


