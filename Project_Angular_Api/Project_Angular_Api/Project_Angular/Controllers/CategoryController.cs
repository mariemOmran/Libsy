using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Angular.DTO;
using Project_Angular.Models;
using Project_Angular.UniteOfwork;

namespace Project_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly _uniteOfwork uniteOfwork;

        public CategoryController(_uniteOfwork _UniteOfwork)
        {
            uniteOfwork = _UniteOfwork;
        }
        [HttpGet]
        [Authorize]
        public ActionResult getAll() {
            List<Category> categories = uniteOfwork.Categories.selectAll().ToList();

            List<CategoryDto> brandDTO = new List<CategoryDto>();
            foreach (Category item in categories)
            {
                CategoryDto obj = new CategoryDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                };
                brandDTO.Add(obj);
            }
            return Ok(brandDTO);
        }
    }
}
