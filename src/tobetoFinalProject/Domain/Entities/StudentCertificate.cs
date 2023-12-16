using Core.Persistence.Repositories;

namespace Domain.Entities;

public class StudentCertificate : Entity<Guid>
{
    public Guid StudentId { get; set; }
    public Guid CerfiticateId { get; set; }
    public virtual Student? Student { get; set; }
    public virtual Certificate? Cerfiticate { get; set; }
}


