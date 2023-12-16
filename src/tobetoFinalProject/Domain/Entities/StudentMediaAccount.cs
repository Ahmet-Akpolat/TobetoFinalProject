using Core.Persistence.Repositories;

namespace Domain.Entities;

public class StudentMediaAccount : Entity<Guid>
{
    public Guid StudentId { get; set; }
    public Guid MediaAccountId { get; set; }
    public virtual Student? Student { get; set; }
    public virtual MediaAccount? MediaAccount { get; set; }
}


