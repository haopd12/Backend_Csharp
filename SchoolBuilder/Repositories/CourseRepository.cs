using Microsoft.EntityFrameworkCore;
using SchoolBuilder.Entities;
using SchoolBuilder.Interfaces;

namespace SchoolBuilder.Repositories
{
	public class CourseRepository: GenericRepository<Course>, ICourseRepository
	{
		public CourseRepository(SchoolContext context) : base(context)
		{
		}
		public IEnumerable<Course> GetPopularCourse(int count)
		{
			return _context.Courses.OrderByDescending(d => d.CourseId).Take(count).ToList();
		}
	}
}
