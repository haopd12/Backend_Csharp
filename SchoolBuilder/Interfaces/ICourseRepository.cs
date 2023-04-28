using SchoolBuilder.Entities;

namespace SchoolBuilder.Interfaces
{
	public interface ICourseRepository : IGenericRepository<Course>
	{
		IEnumerable<Course> GetPopularCourse(int count);
	}
}
