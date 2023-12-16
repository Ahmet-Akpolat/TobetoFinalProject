using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };

        
        #region Announcements
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Delete" });
        #endregion
        #region Categories
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Delete" });
        #endregion
        #region Certificates
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Delete" });
        #endregion
        #region Cities
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Delete" });
        #endregion
        #region ClassAnnouncements
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassAnnouncements.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassAnnouncements.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassAnnouncements.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassAnnouncements.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassAnnouncements.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassAnnouncements.Delete" });
        #endregion
        #region ClassExams
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassExams.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassExams.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassExams.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassExams.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassExams.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassExams.Delete" });
        #endregion
        #region ClassLectures
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassLectures.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassLectures.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassLectures.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassLectures.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassLectures.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ClassLectures.Delete" });
        #endregion
        #region Contents
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contents.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contents.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contents.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contents.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contents.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Contents.Delete" });
        #endregion
        #region ContentCategories
        seeds.Add(new OperationClaim { Id = ++id, Name = "ContentCategories.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ContentCategories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ContentCategories.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ContentCategories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ContentCategories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ContentCategories.Delete" });
        #endregion
        #region ContentInstructors
        seeds.Add(new OperationClaim { Id = ++id, Name = "ContentInstructors.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ContentInstructors.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ContentInstructors.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ContentInstructors.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ContentInstructors.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ContentInstructors.Delete" });
        #endregion
        #region Courses
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Delete" });
        #endregion
        #region CourseContents
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseContents.Delete" });
        #endregion
        #region Districts
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Delete" });
        #endregion
        #region Educations
        seeds.Add(new OperationClaim { Id = ++id, Name = "Educations.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Educations.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Educations.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Educations.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Educations.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Educations.Delete" });
        #endregion
        #region Exams
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Delete" });
        #endregion
        #region Experiences
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Delete" });
        #endregion
        #region Instructors
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Delete" });
        #endregion
        #region Languages
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Languages.Delete" });
        #endregion
        #region LanguageLevels
        seeds.Add(new OperationClaim { Id = ++id, Name = "LanguageLevels.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LanguageLevels.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LanguageLevels.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LanguageLevels.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LanguageLevels.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LanguageLevels.Delete" });
        #endregion
        #region Lectures
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lectures.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lectures.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lectures.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lectures.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lectures.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lectures.Delete" });
        #endregion
        #region LectureCompletionConditions
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureCompletionConditions.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureCompletionConditions.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureCompletionConditions.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureCompletionConditions.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureCompletionConditions.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureCompletionConditions.Delete" });
        #endregion
        #region LectureCourses
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureCourses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureCourses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureCourses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureCourses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureCourses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureCourses.Delete" });
        #endregion
        #region LectureFavourites
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureFavourites.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureFavourites.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureFavourites.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureFavourites.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureFavourites.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureFavourites.Delete" });
        #endregion
        #region LectureLikes
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureLikes.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureLikes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureLikes.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureLikes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureLikes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureLikes.Delete" });
        #endregion
        #region LectureSpentTimes
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureSpentTimes.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureSpentTimes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureSpentTimes.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureSpentTimes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureSpentTimes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureSpentTimes.Delete" });
        #endregion
        #region LectureViews
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureViews.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureViews.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureViews.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureViews.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureViews.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LectureViews.Delete" });
        #endregion
        #region Manufacturers
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturers.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturers.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Manufacturers.Delete" });
        #endregion
        #region MediaAccounts
        seeds.Add(new OperationClaim { Id = ++id, Name = "MediaAccounts.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "MediaAccounts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "MediaAccounts.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "MediaAccounts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "MediaAccounts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "MediaAccounts.Delete" });
        #endregion
        #region Skills
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Skills.Delete" });
        #endregion
        #region Students
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Delete" });
        #endregion
        #region StudentCertificates
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentCertificates.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentCertificates.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentCertificates.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentCertificates.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentCertificates.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentCertificates.Delete" });
        #endregion
        #region StudentClasses
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentClasses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentClasses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentClasses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentClasses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentClasses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentClasses.Delete" });
        #endregion
        #region StudentEducations
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentEducations.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentEducations.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentEducations.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentEducations.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentEducations.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentEducations.Delete" });
        #endregion
        #region StudentExperiences
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentExperiences.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentExperiences.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentExperiences.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentExperiences.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentExperiences.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentExperiences.Delete" });
        #endregion
        #region StudentLanguageLevels
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentLanguageLevels.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentLanguageLevels.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentLanguageLevels.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentLanguageLevels.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentLanguageLevels.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentLanguageLevels.Delete" });
        #endregion
        #region StudentMediaAccounts
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentMediaAccounts.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentMediaAccounts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentMediaAccounts.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentMediaAccounts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentMediaAccounts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentMediaAccounts.Delete" });
        #endregion
        #region StudentSkills
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSkills.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSkills.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSkills.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSkills.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSkills.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentSkills.Delete" });
        #endregion
        #region StudentStudentClasses
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentStudentClasses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentStudentClasses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentStudentClasses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentStudentClasses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentStudentClasses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentStudentClasses.Delete" });
        #endregion
        return seeds;
    }
}
