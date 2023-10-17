namespace ACME.LearningPlatform.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}