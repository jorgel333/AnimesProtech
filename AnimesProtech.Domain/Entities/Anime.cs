using AnimesProtech.Domain.Entities.Abstract;

namespace AnimesProtech.Domain.Entities;

public class Anime : Entity
{
    public string Name { get; set; }
    public string Summary { get; set; }
    public bool Active { get; set; }
   
    public int DirectorId { get; set; }
    public Director Director { get; set; }

    public void Update(string name, string summary, int directorId)
    {
        Name = name;
        Summary = summary;
        DirectorId = directorId;
    }
    public void Disable()
    {
        Active = false;
    }
}
