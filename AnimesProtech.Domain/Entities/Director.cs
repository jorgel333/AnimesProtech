using AnimesProtech.Domain.Entities.Abstract;

namespace AnimesProtech.Domain.Entities;

public class Director : Entity
{
    public string Name { get; set; }
    public IEnumerable<Anime> Animes { get; set; }
}
