using Core.Persistence.Repositories;

namespace Domain.Entities;

public class StudentClass : Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<ClassAnnouncement>? GetClassAnnouncements { get; set; }
    public virtual ICollection<StudentStudentClass>? GetStudentStudentClasses { get; set; }
    public virtual ICollection<ClassExam>? GetClassExams { get; set; }
    public virtual ICollection<ClassLecture>? GetClassLectures { get; set; }
}


