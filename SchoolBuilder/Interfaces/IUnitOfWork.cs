namespace SchoolBuilder.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		int Complete();
	}
}
