namespace ApiNgMovies.Servicios
{
    public interface IStorage
    {
        Task<string> Save(string contenedor, IFormFile file);
        Task Delete(string? path, string contenedor);
        async Task<string> Update(string? path, string contenedor, IFormFile file) 
        { 
            await Delete(path, contenedor);
            return await Save(contenedor, file);
        }
    }
}
