using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsCoreApplication.Repositories
{
  public  interface IStatusesRepository
    {
        List<Model.Status> findAll();

        void insert(Model.Status status);
    }
}
