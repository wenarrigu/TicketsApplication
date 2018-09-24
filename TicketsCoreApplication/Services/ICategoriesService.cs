using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsCoreApplication.Services
{
    public interface ICategoriesService
    {
        List<Model.Category> findAll();

        void insert(Model.Category category);
    }
}
