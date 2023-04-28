using AutoMapper;
using SchoolBuilder.DTOs;
using SchoolBuilder.Entities;

namespace SchoolBuilder
{
	public class AppMapper: Profile
	{
		public AppMapper()
		{
			CreateMap<CourseDTO, Course>();
			CreateMap<StudentDTO, Student>();
			CreateMap<StudentCourseDTO, StudentCourse>();
		}

	}
}
