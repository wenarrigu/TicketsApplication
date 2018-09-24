using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsCoreApplication.Repositories
{
    public interface ICategoriesRespository
    {
        List<Model.Category> findAll();

        void insert(Model.Category category);
    }
}
