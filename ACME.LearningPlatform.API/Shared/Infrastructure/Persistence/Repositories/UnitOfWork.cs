using ACME.LearningPlatform.API.Shared.Domain.Repositories;
using ACME.LearningPlatform.API.Shared.Infrastructure.Persistence.Configuration;

namespace ACME.LearningPlatform.API.Shared.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{

    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}