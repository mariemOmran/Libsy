using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public ImagesController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet("{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            var imagePath = Path.Combine(_env.WebRootPath, "img", imageName); // Assuming your images are in the "img" folder
            if (System.IO.File.Exists(imagePath))
            {
                var imageStream = System.IO.File.OpenRead(imagePath);
                return File(imageStream, "img/jpeg"); // Adjust content type based on your image type
            }
            else
            {
                return NotFound(); // Image file not found
            }
        }

        [HttpPost]
        [Route("upload")]
        [Produces("application/json")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded");
            }

            var uploadsFolder = Path.Combine(_env.WebRootPath, "img");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(file.FileName);
        }
    }
}
