using Microsoft.EntityFrameworkCore;
using SchoolBuilder;
using SchoolBuilder.Interfaces;
using SchoolBuilder.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IStudentCourseRepository, StudentCourseRepository>();
builder.Services.AddTransient<ICourseRepository, CourseRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(Program));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<SchoolContext>(options =>
{
	options.UseNpgsql(
		builder.Configuration.GetConnectionString("NpgConnection"),
		b => b.MigrationsAssembly(typeof(SchoolContext).Assembly.FullName));
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("DefaultConnection"),
		b => b.MigrationsAssembly(typeof(SchoolContext).Assembly.FullName));
}
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
