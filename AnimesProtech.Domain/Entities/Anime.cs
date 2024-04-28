using AnimesProtech.Domain.Entities.Abstract;

namespace AnimesProtech.Domain.Entities;

public class Anime : Entity
{
    public string Name { get; set; }
    public string Summary { get; set; }
    public bool Active { get; set; }
   
    public int DirectorId { get; set; }
    public Director Director { get; set; }

    public void Disable()
    {
        Active = false;
    }
}
