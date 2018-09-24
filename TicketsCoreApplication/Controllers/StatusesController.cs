using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketsCoreApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/Statuses")]
    public class StatusesController : Controller
    {
        private readonly Services.IStatusesService statusesService;

        public StatusesController(Services.IStatusesService iStatusesService)
        {
            statusesService = iStatusesService;
        }

        [HttpGet]
        public IActionResult findAll()
        {
            try
            {
                return Ok(statusesService.findAll());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult insert([FromBody] Model.Status status)
        {
            try
            {
                 statusesService.insert(status);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}