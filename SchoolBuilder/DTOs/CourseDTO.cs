using SchoolBuilder.Entities;

namespace SchoolBuilder.DTOs
{
	public class CourseDTO
	{
		public int CourseId { get; set; }
		public string CourseName { get; set; }
		public string Description { get; set; }

		public List<StudentCourseDTO?> StudentCourses { get; set; }
	}
}
