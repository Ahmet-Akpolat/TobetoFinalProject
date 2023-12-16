using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Domain.Entities;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<ClassAnnouncement> ClassAnnouncements { get; set; }
    public DbSet<ClassExam> ClassExams { get; set; }
    public DbSet<ClassLecture> ClassLectures { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<ContentCategory> ContentCategories { get; set; }
    public DbSet<ContentInstructor> ContentInstructors { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseContent> CourseContents { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<LanguageLevel> LanguageLevels { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<LectureCompletionCondition> LectureCompletionConditions { get; set; }
    public DbSet<LectureCourse> LectureCourses { get; set; }
    public DbSet<LectureFavourite> LectureFavourites { get; set; }
    public DbSet<LectureLike> LectureLikes { get; set; }
    public DbSet<LectureSpentTime> LectureSpentTimes { get; set; }
    public DbSet<LectureView> LectureViews { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<MediaAccount> MediaAccounts { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentCertificate> StudentCertificates { get; set; }
    public DbSet<StudentClass> StudentClasses { get; set; }
    public DbSet<StudentEducation> StudentEducations { get; set; }
    public DbSet<StudentExperience> StudentExperiences { get; set; }
    public DbSet<StudentLanguageLevel> StudentLanguageLevels { get; set; }
    public DbSet<StudentMediaAccount> StudentMediaAccounts { get; set; }
    public DbSet<StudentSkill> StudentSkills { get; set; }
    public DbSet<StudentStudentClass> StudentStudentClasses { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
        //Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
