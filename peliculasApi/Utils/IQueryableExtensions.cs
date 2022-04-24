using peliculasApi.DTOs;

namespace peliculasApi.Utils
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginacionDto paginacionDTO)
        {
            return queryable
                .Skip((paginacionDTO.Pagina - 1) * paginacionDTO.RecordsPorPagina)
                .Take(paginacionDTO.RecordsPorPagina);
        }

    }
}
