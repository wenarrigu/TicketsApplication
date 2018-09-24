using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TicketsCoreApplication.Model;

namespace TicketsCoreApplication.Repositories.Implementations
{
    public class CategoriesRepository : ICategoriesRespository
    {
        public List<Category> findAll()
        {
            List<Category> categories = new List<Category>();
            try
            {
                using (var connection = new SqlConnection("Server=tcp:monge.database.windows.net,1433;Initial Catalog=TicketApplication;Persist Security Info=False;User ID=mongeAdmin;Password=1080aLMQP;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    var command = new SqlCommand("SELECT id,description FROM  Category", connection);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(new Category()
                            {
                                Code = int.Parse(reader["id"].ToString()),
                                Description = reader["description"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }

            return categories;
        }

        public void insert(Category category)
        {
            try
            {
                using (var connection = new SqlConnection("Server=tcp:monge.database.windows.net,1433;Initial Catalog=TicketApplication;Persist Security Info=False;User ID=mongeAdmin;Password=1080aLMQP;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {

                    var command = new SqlCommand("INSERT INTO Category (description) VALUES (@description)", connection);
                   command.Parameters.Add(new SqlParameter("description", category.Description));
                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
