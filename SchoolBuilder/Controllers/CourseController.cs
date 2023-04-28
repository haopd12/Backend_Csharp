using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolBuilder.DTOs;
using SchoolBuilder.Entities;
using SchoolBuilder.Interfaces;

namespace SchoolBuilder.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICourseRepository _courseRepository;
		private readonly IMapper _mapper;
		public CourseController(IUnitOfWork unitOfWork, ICourseRepository courseRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_courseRepository = courseRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetPopularStudents([FromQuery] int count)
		{
			var popular = _courseRepository.GetPopularCourse(count);
			return Ok(popular);
		}

		[HttpPost]
		public IActionResult AddStudent([FromBody] CourseDTO course)
		{
			var c = _mapper.Map<Course>(course);
			Console.WriteLine(c.ToString());
			_courseRepository.Add(c);

			_unitOfWork.Complete();
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateCourse([FromQuery] CourseDTO course)
		{
			var c = _mapper.Map<Course>(course);
			var entity = _courseRepository.GetById(c.CourseId);

			entity.CourseName = c.CourseName;
			entity.Description = c.Description;
			entity.StudentCourses = c.StudentCourses;

			_unitOfWork.Complete();
			return Ok();
		}

		[HttpDelete("id")]
		public IActionResult UpdateStudent([FromQuery] int Id)
		{
			var entity = new Course()
			{
				CourseId = Id
			};
			_courseRepository.Remove(entity);

			_unitOfWork.Complete();
			return Ok();
		}
	}
}
