using Core.Persistence.Repositories;

namespace Domain.Entities;

public class MediaAccount : Entity<Guid>
{
    public string Name { get; set; }
    public string MediaUrl { get; set; }
    public virtual ICollection<StudentMediaAccount>? GetStudentMediaAccounts { get; set; }
}


