using System;
using System.Collections.Generic;
using Xunit;

namespace TicketsCoreApplication.IntegrationTest
{
    /*
     Integration Test
         */
    public class TicketsTest
    {
        public Services.ITicketsService iTicketService;
        TicketsCoreApplication.Controllers.TicketsController ticketsController; 


        public TicketsTest()
        {
            Repositories.ITicketsRepository iTicketRepository = new Repositories.Implementations.TicketsRepository();
            iTicketService = new Services.Implementations.TicketsService(iTicketRepository);
            ticketsController = new Controllers.TicketsController(iTicketService);
        }

        [Fact]
        public void findAll()
        {
            List<Model.Ticket> result = iTicketService.findAll();
            Assert.NotEmpty(result);           
        }

        [Fact]
        public void findByTicketNumber()
        {
            Model.Ticket result = iTicketService.find(1);
            Assert.NotNull(result);
        }

        [Fact]
        public void notFoundByTicketNumber()
        {
            Model.Ticket result = iTicketService.find(100);
            Assert.Null(result);
        }

        [Fact]
        public void upsertTicket()
        {
            Model.Ticket ticket = new Model.Ticket()
            {
                Description = "Test",
                Comment = "Comment",
                Category = new Model.Category()
                {
                    Code = 1            
                },
                Status = new Model.Status()
                {
                    Code = 1
                }

            };

            int newTicketNumber = iTicketService.upsert(ticket);

            Assert.NotEqual(0, newTicketNumber);

        }


    }
}
