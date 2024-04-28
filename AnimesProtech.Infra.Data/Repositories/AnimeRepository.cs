using AnimesProtech.Domain.Entities;
using AnimesProtech.Domain.Interfaces;
using AnimesProtech.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimesProtech.Infra.Data.Repositories;

public class AnimeRepository(AppDbContext context) : IAnimeRepository
{
    private readonly AppDbContext _context = context;
    public void Create(Anime anime)
       => _context.Add(anime);
    
    public async Task<IEnumerable<Anime>> GetAllFilter(string? keyword, int? directorId, CancellationToken cancellationToken)
    {
        var filters = new List<Func<Anime, bool>>();

        var animes = await _context.Animes
                            .Include(x => x.Director)
                            .ToArrayAsync(cancellationToken);

        if (string.IsNullOrWhiteSpace(keyword) is false)
            filters.Add(x => (" " + x.Summary!.ToUpper() + " ").Contains(" " + keyword.ToUpper() + " "));

        if (directorId is not null)
            filters.Add(m => m.DirectorId! == directorId);

        var filterAnimes = filters.Aggregate(animes as IEnumerable<Anime>, (seed, filters) => seed.Where(filters));

        return filterAnimes;
    }

    public void Update(Anime anime)
    {
        _context.Update(anime);
    }
}
