using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsCoreApplication.Services
{
    public interface ITicketsService
    {

        List<Model.Ticket> findAll();

        int upsert(Model.Ticket ticket);

        Model.Ticket find(int ticketNumber);
    }
}
