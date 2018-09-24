using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketsCoreApplication.Controllers
{

    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private readonly Services.ICategoriesService categoryService;

        public CategoriesController(Services.ICategoriesService iCategoryService)
        {
            categoryService = iCategoryService;
        }

        [HttpPost]
        public IActionResult insert([FromBody] Model.Category category)
        {
            try
            {
                categoryService.insert(category);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult findAll()
        {
            try
            {
                List<Model.Category> categories = categoryService.findAll();

                if (categories.Count == 0)
                    NotFound();

                return Ok(categories);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}