using AnimesProtech.Domain.Entities;
using AnimesProtech.Domain.Interfaces.Repositories;
using AnimesProtech.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimesProtech.Infra.Data.Repositories;

public class AnimeRepository(AppDbContext context) : IAnimeRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Anime?> GetById(int id, CancellationToken cancellationToken)
      => await _context.Animes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IEnumerable<Anime>> GetAllFilter(string? name, string? keyword, int? directorId, CancellationToken cancellationToken)
    {
        var filters = new List<Func<Anime, bool>>();

        var animes = await _context.Animes
                            .Include(x => x.Director)
                            .ToArrayAsync(cancellationToken);

        if (string.IsNullOrWhiteSpace(name) is false)
            filters.Add(x => x.Summary!.StartsWith(name, StringComparison.CurrentCultureIgnoreCase));
        
       
        if (string.IsNullOrWhiteSpace(keyword) is false)
            filters.Add(x => x.Summary!.Contains(keyword, StringComparison.CurrentCultureIgnoreCase));

        if (directorId is not null)
            filters.Add(m => m.DirectorId! == directorId);

        var filterAnimes = filters.Aggregate(animes as IEnumerable<Anime>, (seed, filters) => seed.Where(filters));

        return filterAnimes;
    }

    public void Update(Anime anime)
        => _context.Update(anime);

    public void Create(Anime anime)
       => _context.Add(anime);
}
