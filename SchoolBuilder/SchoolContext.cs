using Microsoft.EntityFrameworkCore;
using SchoolBuilder.Entities;
using SchoolBuilder.Interfaces;
using SchoolBuilder.MultiTenancy;

namespace SchoolBuilder
{
	public class SchoolContext: DbContext
	{
		public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
		{
		}
		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<StudentCourse> StudentCourses { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });

			modelBuilder.Entity<StudentCourse>()
				.HasOne<Student>(sc => sc.Student)
				.WithMany(s => s.StudentCourses)
				.HasForeignKey(sc => sc.StudentId);


			modelBuilder.Entity<StudentCourse>()
				.HasOne<Course>(sc => sc.Course)
				.WithMany(s => s.StudentCourses)
				.HasForeignKey(sc => sc.CourseId);
		}

	}
}
