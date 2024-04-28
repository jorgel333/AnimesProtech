namespace AnimesProtech.Domain.Interfaces;

public interface IUnityOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
