using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SchoolBuilder.Interfaces;

namespace SchoolBuilder.Repositories
{
	public class UnitOfWork: IUnitOfWork
	{
		private readonly SchoolContext _context;
		public UnitOfWork(SchoolContext context)
		{
			_context = context;
		}

		public int Complete()
		{
			if (_context.Database.IsNpgsql())
			return _context.SaveChanges();
			return 0;

		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
