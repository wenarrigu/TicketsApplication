using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsCoreApplication.Repositories
{
  public  interface ITicketsRepository
    {
        List<Model.Ticket> findAll();

        int upsert(Model.Ticket ticket);

        Model.Ticket find(int ticketNumber);
    }
}
