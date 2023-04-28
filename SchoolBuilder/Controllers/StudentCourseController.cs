using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolBuilder.DTOs;
using SchoolBuilder.Entities;
using SchoolBuilder.Interfaces;

namespace SchoolBuilder.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentCourseController: ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IStudentCourseRepository _studentCourseRepository;
		private readonly IMapper _mapper;
		public StudentCourseController(IUnitOfWork unitOfWork, IStudentCourseRepository studentCourseRepository, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_studentCourseRepository = studentCourseRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetPopularStudents([FromQuery] int count)
		{
			var popular = _studentCourseRepository.GetPopularStudentCourse(count);
			return Ok(popular);
		}

		[HttpPost]
		public IActionResult AddStudent([FromBody] StudentCourseDTO sc)
		{
			var c = _mapper.Map<StudentCourse>(sc);
			_studentCourseRepository.Add(c);

			_unitOfWork.Complete();
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateStudent([FromBody] StudentCourse sc)
		{
			var entity = _studentCourseRepository.GetById(sc.StudentId);

			entity.StudentId = sc.StudentId;
			entity.CourseId = sc.CourseId;

			_unitOfWork.Complete();
			return Ok();
		}

		[HttpDelete("id")]
		public IActionResult UpdateStudent(int Id)
		{
			var entity = new StudentCourse()
			{
				StudentId = Id
			};
			_studentCourseRepository.Remove(entity);

			_unitOfWork.Complete();
			return Ok();
		}
	}
}
