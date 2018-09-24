using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsCoreApplication.Services
{
   public  interface IStatusesService
    {

        List<Model.Status> findAll();

        void insert(Model.Status status);

    }
}
