using Core.Persistence.Repositories;

namespace Domain.Entities;

public class District : Entity<Guid>
{
    public Guid CityId { get; set; }
    public virtual City? City { get; set; } // Sonradan Eklendi
    public string Name { get; set; }
}


