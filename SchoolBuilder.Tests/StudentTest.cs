using AutoMapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using SchoolBuilder.Controllers;
using SchoolBuilder.DTOs;
using SchoolBuilder.Entities;
using SchoolBuilder.Interfaces;
using SchoolBuilder.Repositories;
using System.Net.WebSockets;
using System.Xml;
using Assert = NUnit.Framework.Assert;

namespace SchoolBuilder.Tests;

[TestClass]
public class StudentTest
{
    private Mock<SchoolContext> _context;
    private Mock<IStudentRepository> _studentRepository;
    private StudentController _studentController;
    private IMapper _mapper;
    private IUnitOfWork _unitOfWork;

    [TestInitialize]
    public void TestInitialize()
    {
        _studentRepository = new Mock<IStudentRepository>();

        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var options = new DbContextOptionsBuilder<SchoolContext>()
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            .Options;
        _context = new Mock<SchoolContext>(options);
        _unitOfWork = new UnitOfWork(_context.Object);

        
        if (_mapper == null)
		{
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new AppMapper());
			});
			IMapper mapper = mappingConfig.CreateMapper();
			_mapper = mapper;
		}
        _studentController = new StudentController(_studentRepository.Object, _unitOfWork, _mapper);
    }

	[TestMethod]
    public void TestGetMethod()
    {
        var student = new Student();
        student.Name = "test";
        student.StudentId = 1;
        student.StudentCourses = new List<StudentCourse>();
        _studentRepository.Setup(x => x.GetById(1)).Returns(student);

		var response = _studentController.GetById(1);


        Assert.IsNotNull(response);

        var okResult = (OkObjectResult) response;
        Assert.AreEqual(student, okResult.Value);
	}

    [TestMethod]
    public void TestPostMethod()
    {
        var student = new StudentDTO();
        student.Name = "test";
        student.StudentId= 1;
       /* student.StudentCourses = list;*/

        var s = _mapper.Map<Student>(student);
		_studentRepository.Setup(x => x.Add(s));


        var result = _studentController.AddStudent(student);
        Assert.IsNotNull(result);
        var createdResult = (OkResult) result;
        Assert.AreEqual(StatusCodes.Status200OK, createdResult.StatusCode);
    }

    [TestMethod]
    public void TestDeleteMethod()
    {
		var student = new Student();
		student.Name = "test";
		student.StudentId = 1;
		student.StudentCourses = new List<StudentCourse>();
		_studentRepository.Setup(x => x.GetById(1)).Returns(student);

        var result = _studentController.DeleteStudent(1);
        Assert.IsNotNull(result);
        var createdResult = (OkResult) result;
		Assert.AreEqual(StatusCodes.Status200OK, createdResult.StatusCode);
	}

    [TestMethod]
    public void TestUpdateMethod()
    {
		var student = new Student();
		student.Name = "test";
		student.StudentId = 1;
		student.StudentCourses = new List<StudentCourse>();
		_studentRepository.Setup(x => x.GetById(1)).Returns(student);

        var result = _studentController.UpdateStudent(student); 
        Assert.IsNotNull(result);
        var createdResult = (OkResult) result;
		Assert.AreEqual(StatusCodes.Status200OK, createdResult.StatusCode);

	}
}