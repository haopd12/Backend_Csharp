using SchoolBuilder.Entities;

namespace SchoolBuilder.DTOs
{
	public class StudentDTO
	{
		public int StudentId { get; set; }
		public string Name { get; set; }
		
		public List<StudentCourseDTO?>? StudentCourses { get; set; }
	}
}
