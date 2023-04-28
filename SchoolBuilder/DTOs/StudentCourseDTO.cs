using SchoolBuilder.Entities;

namespace SchoolBuilder.DTOs
{
	public class StudentCourseDTO
	{
		public int StudentId { get; set; }
		public StudentDTO? Student { get; set; }

		public int CourseId { get; set; }
		public CourseDTO? Course { get; set; }
	}
}
