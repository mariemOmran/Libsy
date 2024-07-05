using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Angular.DTO;
using Project_Angular.Models;
using Project_Angular.UniteOfwork;

namespace Project_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly _uniteOfwork uniteOfwork;

        public BrandController(_uniteOfwork uniteOfwork)
        {
            this.uniteOfwork = uniteOfwork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Brand> brands = uniteOfwork.Brands.selectAll().ToList();
            
          List<BrandDTO>brandDTO = new List<BrandDTO>();
            foreach(Brand item in brands)
            {
                BrandDTO obj = new BrandDTO() { 
                Id = item.Id,
                Name = item.Name,
                };
                brandDTO.Add(obj);  
            }
            return Ok(brandDTO);
            
        }
    }
}
