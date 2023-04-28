using SchoolBuilder.Entities;

namespace SchoolBuilder.Interfaces
{
	public interface IStudentCourseRepository: IGenericRepository<StudentCourse>
	{
		IEnumerable<StudentCourse> GetPopularStudentCourse(int count);

	}
}
