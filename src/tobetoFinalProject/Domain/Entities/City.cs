using Core.Persistence.Repositories;

namespace Domain.Entities;

public class City : Entity<Guid>
{
    public string Name { get; set; }
}


