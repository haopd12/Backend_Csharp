using SchoolBuilder.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SchoolBuilder.Interfaces
{
	public interface IStudentRepository : IGenericRepository<Student>
	{
		IEnumerable<Student> GetPopularStudent(int count);
	}
}
