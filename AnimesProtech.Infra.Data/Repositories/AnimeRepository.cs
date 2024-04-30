using AnimesProtech.Application.Extensions;
using AnimesProtech.Domain;
using AnimesProtech.Domain.Entities;
using AnimesProtech.Domain.Interfaces.Repositories;
using AnimesProtech.Infra.Data.Context;
using AnimesProtech.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AnimesProtech.Infra.Data.Repositories;

public class AnimeRepository(AppDbContext context) : IAnimeRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Anime?> GetById(int id, CancellationToken cancellationToken)
      => await _context.Animes.Include(x => x.Director).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public Task<IEnumerable<Anime>> GetAllFilter(PaginasteQueryOptions paginasteQueryOptions, string? name, string? keyword, int? directorId, CancellationToken cancellationToken)
    {
        var filters = new List<Func<Anime, bool>>();

        var animes =  _context.Animes
                            .Include(x => x.Director).PaginateAndOrder(paginasteQueryOptions, x => x.Name);

        if (string.IsNullOrWhiteSpace(name) is false)
            filters.Add(x => x.Name!.StartsWith(name.Trim(), StringComparison.CurrentCultureIgnoreCase));
       
        if (string.IsNullOrWhiteSpace(keyword) is false)
            filters.Add(x => x.Summary!.RemoveAccents().Contains(keyword.Trim().RemoveAccents(), StringComparison.CurrentCultureIgnoreCase));

        if (directorId is not null)
            filters.Add(m => m.DirectorId! == directorId);

        var filterAnimes = filters.Aggregate(animes as IEnumerable<Anime>, (seed, filters) => seed.Where(filters));

        return Task.FromResult(filterAnimes);
    }

    public void Update(Anime anime)
        => _context.Update(anime);

    public void Create(Anime anime)
       => _context.Add(anime);
}
