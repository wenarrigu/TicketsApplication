using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketsCoreApplication.Web.Models;
using Microsoft.Extensions.Http;

namespace TicketsCoreApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/categories")]
        public IActionResult LoadCategories()
        {
            try
            {
                List<Model.Category> categories = new List<Model.Category>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://ticketscoreapplication20180922064643.azurewebsites.net");

                    var result = client.GetAsync("/api/categories").Result;

                    categories = result.Content.ReadAsAsync<List<Model.Category>>().Result;

                    
                }               

                return Ok(categories);

            }catch(Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("api/statuses")]
        public IActionResult LoadStatuses()
        {
            try
            {
                List<Model.Status> statuses = new List<Model.Status>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://ticketscoreapplication20180922064643.azurewebsites.net");

                    var result = client.GetAsync("/api/statuses").Result;

                    statuses = result.Content.ReadAsAsync<List<Model.Status>>().Result;


                }

                return Ok(statuses);

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        [HttpGet]
        [Route("api/tickets")]
        public IActionResult LoadTickets()
        {
            try
            {
                List<Model.Ticket> tickets = new List<Model.Ticket>();

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://ticketscoreapplication20180922064643.azurewebsites.net");

                    var result = client.GetAsync("/api/tickets").Result;

                    tickets = result.Content.ReadAsAsync<List<Model.Ticket>>().Result;


                }

                return Ok(tickets);

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        [HttpPost]
        [Route("api/upsert")]
        public IActionResult Upsert(int ticketNumber ,string description,string comment, int status,int category)
        {
            try
            {
                Model.Ticket ticket = new Model.Ticket()
                {
                    TicketNumber = ticketNumber,
                    Description = description,
                    Comment = comment == null? string.Empty : comment ,
                    Status = new Model.Status() { Code = status},
                    Category = new Model.Category() { Code = category}
                };
                int ticketID = 0;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://ticketscoreapplication20180922064643.azurewebsites.net");

                     ticketID = client.PostAsJsonAsync<Model.Ticket>("/api/tickets",ticket).Result.Content.ReadAsAsync<int>().Result;                   
                }
                return Ok(ticketID);

            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }
    }
}
