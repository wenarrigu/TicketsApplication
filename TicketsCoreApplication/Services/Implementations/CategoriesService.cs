using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsCoreApplication.Model;

namespace TicketsCoreApplication.Services.Implementations
{
    public class CategoriesService : ICategoriesService
    {

        private readonly Repositories.ICategoriesRespository categoriesRespository;

        public CategoriesService(Repositories.ICategoriesRespository iCategoriesRespository)
        {
            categoriesRespository = iCategoriesRespository;
        }

        public List<Category> findAll()
        {
            try
            {
              return categoriesRespository.findAll();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void insert(Category category)
        {
            try
            {
                categoriesRespository.insert(category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
