using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Registro.API.Repositories
{
    public interface IImageRepository
    {
        Task<string> Upload(IFormFile file, string fileName);
    }
}
