using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketsCoreApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/tickets")]
    public class TicketsController : Controller
    {
        private readonly Services.ITicketsService ticketsService;

        public TicketsController(Services.ITicketsService ITicketsService )
        {
            ticketsService = ITicketsService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult findAll()
        {
            try
            {
                List<Model.Ticket> tickets = ticketsService.findAll();

                if (tickets.Count == 0)
                    return NotFound();

                return Ok(tickets);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{ticketNumber}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult find(int ticketNumber)
        {
            try
            {
                Model.Ticket ticket = ticketsService.find(ticketNumber);

                if (ticket == null)
                    return NotFound();

                return Ok(ticket);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult upsert([FromBody] Model.Ticket ticket)
        {
            try
            {
                 int ticketNumber = ticketsService.upsert(ticket);
                return Ok(ticketNumber);
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}