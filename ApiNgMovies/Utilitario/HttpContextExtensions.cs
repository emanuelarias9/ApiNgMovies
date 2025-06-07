using Microsoft.EntityFrameworkCore;

namespace ApiNgMovies.Utilitario
{
    public static class HttpContextExtensions
    {
        public async static Task ParametrosPaginacion<T>(this HttpContext httpContext,IQueryable<T> queryable) 
        {
            if (httpContext is null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }
            double cantidadRegistros = await queryable.CountAsync();
            httpContext.Response.Headers.Append("cantidadRegistros", cantidadRegistros.ToString());
        }
    }
}
