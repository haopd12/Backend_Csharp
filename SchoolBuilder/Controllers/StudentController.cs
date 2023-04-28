using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolBuilder.DTOs;
using SchoolBuilder.Entities;
using SchoolBuilder.Interfaces;

namespace SchoolBuilder.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController: ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IStudentRepository _studentRepository;
		private readonly IMapper _mapper;
		public StudentController(IStudentRepository studentRepository, IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_studentRepository = studentRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetPopularStudents([FromQuery] int count)
		{
			var popular = _studentRepository.GetPopularStudent(count);
			return Ok(popular);
		}

		[HttpGet("id")]
		public IActionResult GetById([FromQuery] int id)
		{
			var student = _studentRepository.GetById(id);
			return Ok(student);
		}


		[HttpPost]
		public IActionResult AddStudent([FromBody] StudentDTO student)
		{
			var c = _mapper.Map<Student>(student);
			_studentRepository.Add(c);

			_unitOfWork.Complete();
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateStudent([FromQuery] Student student)
		{
			var c = _mapper.Map<Student>(student);
			var entity = _studentRepository.GetById(c.StudentId);

			entity.Name = c.Name;
			entity.StudentCourses = c.StudentCourses;

			_unitOfWork.Complete();
			return Ok();
		}

		[HttpDelete("id")]
		public IActionResult DeleteStudent([FromQuery]int Id)
		{
			var entity = new Student()
			{
				StudentId = Id
			};
			_studentRepository.Remove(entity);

			_unitOfWork.Complete();
			return Ok();
		}
	}
}
