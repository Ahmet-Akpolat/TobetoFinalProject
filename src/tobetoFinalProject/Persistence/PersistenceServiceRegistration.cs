using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<BaseDbContext>(options =>options.UseInMemoryDatabase("nArchitecture")));
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("TobetoPlatformConnectionString")
    ));
        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICertificateRepository, CertificateRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IClassAnnouncementRepository, ClassAnnouncementRepository>();
        services.AddScoped<IClassExamRepository, ClassExamRepository>();
        services.AddScoped<IClassLectureRepository, ClassLectureRepository>();
        services.AddScoped<IContentRepository, ContentRepository>();
        services.AddScoped<IContentCategoryRepository, ContentCategoryRepository>();
        services.AddScoped<IContentInstructorRepository, ContentInstructorRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ICourseContentRepository, CourseContentRepository>();
        services.AddScoped<IDistrictRepository, DistrictRepository>();
        services.AddScoped<IEducationRepository, EducationRepository>();
        services.AddScoped<IExamRepository, ExamRepository>();
        services.AddScoped<IExperienceRepository, ExperienceRepository>();
        services.AddScoped<IInstructorRepository, InstructorRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<ILanguageLevelRepository, LanguageLevelRepository>();
        services.AddScoped<ILectureRepository, LectureRepository>();
        services.AddScoped<ILectureCompletionConditionRepository, LectureCompletionConditionRepository>();
        services.AddScoped<ILectureCourseRepository, LectureCourseRepository>();
        services.AddScoped<ILectureFavouriteRepository, LectureFavouriteRepository>();
        services.AddScoped<ILectureLikeRepository, LectureLikeRepository>();
        services.AddScoped<ILectureSpentTimeRepository, LectureSpentTimeRepository>();
        services.AddScoped<ILectureViewRepository, LectureViewRepository>();
        services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
        services.AddScoped<IMediaAccountRepository, MediaAccountRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IStudentCertificateRepository, StudentCertificateRepository>();
        services.AddScoped<IStudentClassRepository, StudentClassRepository>();
        services.AddScoped<IStudentEducationRepository, StudentEducationRepository>();
        services.AddScoped<IStudentExperienceRepository, StudentExperienceRepository>();
        services.AddScoped<IStudentLanguageLevelRepository, StudentLanguageLevelRepository>();
        services.AddScoped<IStudentMediaAccountRepository, StudentMediaAccountRepository>();
        services.AddScoped<IStudentSkillRepository, StudentSkillRepository>();
        services.AddScoped<IStudentStudentClassRepository, StudentStudentClassRepository>();
        return services;
    }
}
