using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public class Student : Entity<Guid>
{
    public virtual User? User { get; set; }
    public Guid CityId { get; set; }
    public Guid DistrictId { get; set; }
    public string NationalIdentity { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
    public string? AddressDetail { get; set; }
    public string? Description { get; set; }
    public string? ProfilePhotoPath { get; set; }
    public string Country { get; set; }
    public virtual City? City { get; set; }
    public virtual District? District { get; set; }
    public virtual ICollection<StudentEducation>? GetStudentEducations { get; set; }
    public virtual ICollection<StudentExperience>? GetStudentExperiences { get; set; }
    public virtual ICollection<StudentStudentClass>? GetStudentStudentClasses { get; set; }
    public virtual ICollection<StudentLanguageLevel>? GetStudentLanguageLevels { get; set; }
    public virtual ICollection<StudentSkill>? GetStudentSkills { get; set; }
    public virtual ICollection<StudentMediaAccount>? GetStudentMediaAccounts { get; set; }
    public virtual ICollection<StudentCertificate>? GetStudentCertificates { get; set; }
}

