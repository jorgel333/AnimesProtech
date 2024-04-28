using AnimesProtech.Domain.Interfaces;
using AnimesProtech.Infra.Data.Context;

namespace AnimesProtech.Infra.Data;

public class UnityOfWork(AppDbContext context) : IUnityOfWork
{
    private readonly AppDbContext _context = context;
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
    public void Dispose()
        => _context.Dispose();
}
