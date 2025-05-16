using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileProcessController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var path = Path.Combine("C:\\Users\\bayul\\Desktop\\MyProject\\Frontend\\HotelProject.WebUI\\wwwroot\\files\\", fileName);

            await using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);

            return Created("", new { fileName });
        }
    }
}
