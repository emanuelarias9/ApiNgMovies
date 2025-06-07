using ApiNgMovies.DTOs;

namespace ApiNgMovies.Utilitario
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginacionDTO paginacion)
        {
            if (paginacion.Page < 1) throw new ArgumentOutOfRangeException(nameof(paginacion.Page), "Page must be greater than or equal to 1.");
            if (paginacion.PageSize < 1) throw new ArgumentOutOfRangeException(nameof(paginacion.PageSize), "Page size must be greater than or equal to 1.");
            return queryable.Skip((paginacion.Page - 1) * paginacion.PageSize).Take(paginacion.PageSize);
        }
    }
}
