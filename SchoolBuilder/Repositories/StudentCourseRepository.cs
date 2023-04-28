using Microsoft.EntityFrameworkCore;
using SchoolBuilder.Entities;
using SchoolBuilder.Interfaces;

namespace SchoolBuilder.Repositories
{
	public class StudentCourseRepository: GenericRepository<StudentCourse>, IStudentCourseRepository
	{
		public StudentCourseRepository(SchoolContext context) : base(context)
		{
		}
		public IEnumerable<StudentCourse> GetPopularStudentCourse(int count)
		{
			return _context.StudentCourses.OrderByDescending(d => d.CourseId).Take(count).ToList();
		}
	}
}
