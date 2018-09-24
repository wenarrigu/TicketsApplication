using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsCoreApplication.Model;

namespace TicketsCoreApplication.Services.Implementations
{
    public class StatusesService : IStatusesService
    {

        private readonly Repositories.IStatusesRepository statusesRespository;

        public StatusesService(Repositories.IStatusesRepository iStatusesRespository)
        {
            statusesRespository = iStatusesRespository;
        }

        public List<Status> findAll()
        {
            try
            {
                return statusesRespository.findAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void insert(Status status)
        {
            try
            {
                 statusesRespository.insert(status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
