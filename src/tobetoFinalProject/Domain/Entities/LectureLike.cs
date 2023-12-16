using Core.Persistence.Repositories;

namespace Domain.Entities;

public class LectureLike : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid LectureId { get; set; }
    public virtual Student? Student { get; set; }
    public virtual Lecture? Lecture { get; set; }
}


