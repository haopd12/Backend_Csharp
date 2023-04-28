using Microsoft.EntityFrameworkCore;
using SchoolBuilder.Entities;
using SchoolBuilder.Interfaces;

namespace SchoolBuilder.Repositories
{
	public class StudentRepository: GenericRepository<Student>, IStudentRepository
	{
		public StudentRepository(SchoolContext context) : base(context)
		{
		}
		public IEnumerable<Student> GetPopularStudent(int count)
		{
			return _context.Students.OrderByDescending(d => d.StudentId).Take(count).ToList();
		}
	}
}
