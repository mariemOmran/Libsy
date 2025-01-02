using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project_Angular.DTO;
using Project_Angular.Models;
using Project_Angular.Reposatry;
using Project_Angular.UniteOfwork;
using System;

namespace Project_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly _uniteOfwork uniteOfwork;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ProductsController(_uniteOfwork  UniteOfwork, IWebHostEnvironment hostingEnvironment)
        {
            uniteOfwork = UniteOfwork;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult index() {
            IQueryable<Clothes> clothes = uniteOfwork.Clothes.GetAllIncluding(n => n.brand, n => n.category);
            List<ProductsWihtCateNameDTO> pdto = new List<ProductsWihtCateNameDTO>();
            foreach (var clath in clothes)
            {
                string imageName = clath.Image; // Assuming 'Image' property contains the image filename
                string imageUrl = Url.Action("GetImage", "Images", new { imageName = imageName }, Request.Scheme);
                ProductsWihtCateNameDTO productsWithCategoryNameDTO = new ProductsWihtCateNameDTO()
                {
                    id = clath.Id,
                    brandName = clath.brand.Name,
                    Name = clath.Name,
                    CategoryName = clath.category.Name,
                    Price = clath.Price,
                    Image = imageUrl,
                    Description = clath.Description,
                    Qunatity = clath.Qunatity,
                    Rate = clath.Rate
                };
                pdto.Add(productsWithCategoryNameDTO);
            }

            return Ok(pdto);
        }
        [HttpPost("filter")]
        //public IActionResult FilterProducts( ProductFilterationModel filter)
        public IActionResult FilterProducts(ProductFilterationModel filter)
        {
            
            IQueryable<Clothes> clothes = uniteOfwork.Clothes.GetAllIncluding(n => n.brand, n => n.category);
            if (filter.Categories.Count() != 0 && filter.Brands.Count() != 0)
            {
                clothes = clothes.Where(n => filter.Categories.Contains(n.category.Id) || filter.Brands.Contains(n.brand.Id));
            }
            else if (filter.Categories.Count() != 0) {
                clothes = clothes.Where(n =>  filter.Categories.Contains(n.brand.Id));
            }
            else if(filter.Brands.Count() != 0) {
                clothes = clothes.Where(n => filter.Brands.Contains(n.brand.Id));
            }
            int countAllClothes = clothes.Count();
            clothes = clothes.Skip((filter.PageNumber-1)*filter.PageSize).Take(filter.PageSize);
            
            List<ProductsWihtCateNameDTO> pdto = new List<ProductsWihtCateNameDTO>();
            foreach (var clath in clothes) {
                string imageName = clath.Image; // Assuming 'Image' property contains the image filename
                string imageUrl = Url.Action("GetImage", "Images", new { imageName = imageName }, Request.Scheme);
                ProductsWihtCateNameDTO productsWithCategoryNameDTO = new ProductsWihtCateNameDTO()
                {
                    id = clath.Id,
                    brandName = clath.brand.Name,
                    Name = clath.Name,
                    CategoryName = clath.category.Name,
                    Price = clath.Price,
                    Image = imageUrl,
                    Description = clath.Description,
                    Qunatity = clath.Qunatity,
                    Rate = clath.Rate
                };
                pdto.Add(productsWithCategoryNameDTO);
            }

            PagingProducts result = new PagingProducts
            {

                products = pdto,
                pageNumber = filter.PageNumber,
                PageSize = countAllClothes / filter.PageSize
            };

            return Ok(result);
        }


        [HttpGet("id")]
        public IActionResult GetById(int id) {
            var clath = uniteOfwork.Clothes.GetAllIncluding(n => n.category, n => n.brand).Where(n=>n.Id==id).FirstOrDefault();
            string imageName = clath.Image; // Assuming 'Image' property contains the image filename
            string imageUrl = Url.Action("GetImage", "Images", new { imageName = imageName }, Request.Scheme);
            ProductsWihtCateNameDTO objDto = new ProductsWihtCateNameDTO()
            {
                id = clath.Id,
                brandName = clath.brand.Name,
                Name = clath.Name,
                CategoryName = clath.category.Name,
                Price = clath.Price,
                Image = imageUrl,
                Description = clath.Description,
                Qunatity = clath.Qunatity,
                Rate = clath.Rate

            };
            return Ok(objDto);
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
          Clothes cl =   uniteOfwork.Clothes.Delete(id);
            uniteOfwork.save();
            if (cl != null)
            {
                return Ok(cl);
            }
            else
            {
                return BadRequest("enter valid id");
            }

        }
        [HttpPut]
        public IActionResult UpdateById(ProductsWihtCateNameDTO obj)
        {
            Brand brand= uniteOfwork.Brands.selectAll().FirstOrDefault(n=>n.Name==obj.brandName);
            Category category= uniteOfwork.Categories.selectAll().FirstOrDefault(n=>n.Name==obj.CategoryName);
            string fileNameWithExtension = System.IO.Path.GetFileName(new Uri(obj.Image).LocalPath);
            Clothes clothes = new Clothes() {
                Id = obj.id,
            Description = obj.Description,
            Image = fileNameWithExtension,
            Qunatity=obj.Qunatity,
            Rate = obj.Rate,
            Name = obj.Name,
            Price = obj.Price,
            categoryID=category.Id,
            brandID=brand.Id
            };
            Clothes cl = uniteOfwork.Clothes.update(clothes);
            uniteOfwork.save();
            if (cl != null)
            {
                return Ok();

            }
            else
            {
                return BadRequest("error");
            }
        }
        [HttpPut("add")]
        //public async Task<IActionResult> Add(AddProduct clothes, IFormFile image)
        //{
        //    if (image == null || image.Length == 0)
        //    {
        //        return BadRequest("No image uploaded");
        //    }

        //    // Generate a unique filename for the uploaded image
        //    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(image.FileName);

        //    // Get the path to the wwwroot folder
        //    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "uploads");

        //    // Ensure the uploads folder exists
        //    if (!Directory.Exists(uploadsFolder))
        //    {
        //        Directory.CreateDirectory(uploadsFolder);
        //    }

        //    // Combine the uploads folder path with the unique filename
        //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //    // Save the image file to the server
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await image.CopyToAsync(stream);
        //    }

        //    // Save the filename or the path to the image file in the database
        //    Clothes obj = new Clothes()
        //    {
        //        brandID = clothes.brandid,
        //        categoryID = clothes.Categoryid,
        //        Name = clothes.Name,
        //        Price = clothes.Price,
        //        Qunatity = clothes.Qunatity,
        //        Description = clothes.Description,
        //        Image = uniqueFileName // Save the filename in the database
        //    };

        //    // Add the other properties of obj as needed based on your business logic

        //    Clothes cl = uniteOfwork.Clothes.add(obj);
        //    uniteOfwork.save();

        //    if (cl != null)
        //    {
        //        return Ok(cl);
        //    }
        //    else
        //    {
        //        return BadRequest("Error adding product");
        //    }
        //}
        public IActionResult Add(AddProduct clothes)
        {
            Clothes obj = new Clothes()
            {
                brandID = clothes.brandid,
                categoryID = clothes.Categoryid,
                Name = clothes.Name,
                Price = clothes.Price,
                Qunatity = clothes.Qunatity,
                Image = clothes.Image,
                Description = clothes.Description,

            };
            Clothes cl = uniteOfwork.Clothes.add(obj);
            uniteOfwork.save();
            if (cl != null)
            {
                return Ok(cl);
            }
            else
            {
                return BadRequest("error");
            }
        }


    }
}
