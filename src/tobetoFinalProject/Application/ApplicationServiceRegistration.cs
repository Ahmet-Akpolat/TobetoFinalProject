using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Core.ElasticSearch;
using Core.Mailing;
using Core.Mailing.MailKitImplementations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Services.Announcements;
using Application.Services.Categories;
using Application.Services.Certificates;
using Application.Services.Cities;
using Application.Services.ClassAnnouncements;
using Application.Services.ClassExams;
using Application.Services.ClassLectures;
using Application.Services.Contents;
using Application.Services.ContentCategories;
using Application.Services.ContentInstructors;
using Application.Services.Courses;
using Application.Services.CourseContents;
using Application.Services.Districts;
using Application.Services.Educations;
using Application.Services.Exams;
using Application.Services.Experiences;
using Application.Services.Instructors;
using Application.Services.Languages;
using Application.Services.LanguageLevels;
using Application.Services.Lectures;
using Application.Services.LectureCompletionConditions;
using Application.Services.LectureCourses;
using Application.Services.LectureFavourites;
using Application.Services.LectureLikes;
using Application.Services.LectureSpentTimes;
using Application.Services.LectureViews;
using Application.Services.Manufacturers;
using Application.Services.MediaAccounts;
using Application.Services.Skills;
using Application.Services.Students;
using Application.Services.StudentCertificates;
using Application.Services.StudentClasses;
using Application.Services.StudentEducations;
using Application.Services.StudentExperiences;
using Application.Services.StudentLanguageLevels;
using Application.Services.StudentMediaAccounts;
using Application.Services.StudentSkills;
using Application.Services.StudentStudentClasses;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>();
        services.AddSingleton<LoggerServiceBase, FileLogger>();
        services.AddSingleton<IElasticSearch, ElasticSearchManager>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddScoped<IAnnouncementsService, AnnouncementsManager>();
        services.AddScoped<ICategoriesService, CategoriesManager>();
        services.AddScoped<ICertificatesService, CertificatesManager>();
        services.AddScoped<ICitiesService, CitiesManager>();
        services.AddScoped<IClassAnnouncementsService, ClassAnnouncementsManager>();
        services.AddScoped<IClassExamsService, ClassExamsManager>();
        services.AddScoped<IClassLecturesService, ClassLecturesManager>();
        services.AddScoped<IContentsService, ContentsManager>();
        services.AddScoped<IContentCategoriesService, ContentCategoriesManager>();
        services.AddScoped<IContentInstructorsService, ContentInstructorsManager>();
        services.AddScoped<ICoursesService, CoursesManager>();
        services.AddScoped<ICourseContentsService, CourseContentsManager>();
        services.AddScoped<IDistrictsService, DistrictsManager>();
        services.AddScoped<IEducationsService, EducationsManager>();
        services.AddScoped<IExamsService, ExamsManager>();
        services.AddScoped<IExperiencesService, ExperiencesManager>();
        services.AddScoped<IInstructorsService, InstructorsManager>();
        services.AddScoped<ILanguagesService, LanguagesManager>();
        services.AddScoped<ILanguageLevelsService, LanguageLevelsManager>();
        services.AddScoped<ILecturesService, LecturesManager>();
        services.AddScoped<ILectureCompletionConditionsService, LectureCompletionConditionsManager>();
        services.AddScoped<ILectureCoursesService, LectureCoursesManager>();
        services.AddScoped<ILectureFavouritesService, LectureFavouritesManager>();
        services.AddScoped<ILectureLikesService, LectureLikesManager>();
        services.AddScoped<ILectureSpentTimesService, LectureSpentTimesManager>();
        services.AddScoped<ILectureViewsService, LectureViewsManager>();
        services.AddScoped<IManufacturersService, ManufacturersManager>();
        services.AddScoped<IMediaAccountsService, MediaAccountsManager>();
        services.AddScoped<ISkillsService, SkillsManager>();
        services.AddScoped<IStudentsService, StudentsManager>();
        services.AddScoped<IStudentCertificatesService, StudentCertificatesManager>();
        services.AddScoped<IStudentClassesService, StudentClassesManager>();
        services.AddScoped<IStudentEducationsService, StudentEducationsManager>();
        services.AddScoped<IStudentExperiencesService, StudentExperiencesManager>();
        services.AddScoped<IStudentLanguageLevelsService, StudentLanguageLevelsManager>();
        services.AddScoped<IStudentMediaAccountsService, StudentMediaAccountsManager>();
        services.AddScoped<IStudentSkillsService, StudentSkillsManager>();
        services.AddScoped<IStudentStudentClassesService, StudentStudentClassesManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
