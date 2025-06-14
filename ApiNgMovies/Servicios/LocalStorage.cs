
namespace ApiNgMovies.Servicios
{
    public class LocalStorage : IStorage
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LocalStorage(IWebHostEnvironment env,IHttpContextAccessor httpContextAccessor)
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }
        public Task Delete(string? path, string contenedor)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return Task.CompletedTask;
            }

            var fileName = Path.GetFileName(path);
            var filePath = Path.Combine(env.WebRootPath, contenedor,fileName);
            
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Task.CompletedTask;
        }

        public async Task<string> Save(string contenedor, IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{extension}";
            var folder = Path.Combine(env.WebRootPath, contenedor);
            var path = Path.Combine(folder, fileName);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            using(var stream= new MemoryStream())
            {
                await file.CopyToAsync(stream);
                var content = stream.ToArray();
                await File.WriteAllBytesAsync(path, content);
            }

            var request = httpContextAccessor.HttpContext!.Request;
            var url = $"{request.Scheme}://{request.Host}";
            var fileUrl= Path.Combine(url, contenedor, fileName).Replace("\\", "/");
            return fileUrl;
        }
    }
}
