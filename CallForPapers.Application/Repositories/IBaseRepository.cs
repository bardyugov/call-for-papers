namespace CallForPapers.Application.Repositories;

public interface IBaseRepository
{
    Task SaveChanges(CancellationToken token);
}