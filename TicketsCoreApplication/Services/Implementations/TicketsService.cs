using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsCoreApplication.Model;

namespace TicketsCoreApplication.Services.Implementations
{
    public class TicketsService : ITicketsService
    {
        private readonly Repositories.ITicketsRepository ticketsRepository;

        public TicketsService(Repositories.ITicketsRepository iTicketsRepository)
        {
            ticketsRepository = iTicketsRepository;
        }

        public Ticket find(int ticketNumber)
        {
            try
            {
                Model.Ticket ticket = ticketsRepository.find(ticketNumber);

                if (JsonConvert.SerializeObject(ticket) == JsonConvert.SerializeObject(new Model.Ticket()))
                    return null;

               return ticket;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ticket> findAll()
        {

            try
            {
                return ticketsRepository.findAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int upsert(Ticket ticket)
        {

            try
            {
               return ticketsRepository.upsert(ticket);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
