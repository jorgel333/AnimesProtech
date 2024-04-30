namespace AnimesProtech.Domain;

public record PaginasteQueryOptions(int Page, int PageSize = 10, bool? IsDescending = null)
{
    public int ItensToSkip => PageSize * (Page - 1);
}
