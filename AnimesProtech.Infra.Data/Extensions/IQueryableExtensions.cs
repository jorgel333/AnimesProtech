using AnimesProtech.Domain;

namespace AnimesProtech.Infra.Data.Extensions;

public static class IQueryableExtensions
{
    public static IEnumerable<TSource> PaginateAndOrder<TSource, TOrderTarget>(this IEnumerable<TSource> queryble,
    PaginasteQueryOptions paginatedQueryOptions, Func<TSource, TOrderTarget> orderFunction)
    {
        var paginated = paginatedQueryOptions.IsDescending switch
        {
            true => queryble.OrderByDescending(orderFunction),
            false => queryble.OrderBy(orderFunction),
            _ => queryble
        };
       
        return paginated.Skip(paginatedQueryOptions.ItensToSkip).Take(paginatedQueryOptions.PageSize);
    }
}
