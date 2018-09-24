using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TicketsCoreApplication.Model;

namespace TicketsCoreApplication.Repositories.Implementations
{
    public class StatusesRepository : IStatusesRepository
    {
        public List<Status> findAll()
        {
            List<Status> statuses = new List<Status>();
            try
            {
                using (var connection = new SqlConnection("Server=tcp:monge.database.windows.net,1433;Initial Catalog=TicketApplication;Persist Security Info=False;User ID=mongeAdmin;Password=1080aLMQP;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    var command = new SqlCommand("SELECT id,name FROM  Status", connection);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            statuses.Add(new Status()
                            {
                                Code = int.Parse(reader["id"].ToString()),
                                Name = reader["name"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }

            return statuses;
        }

        public void insert(Status status)
        {
            try
            {
                using (var connection = new SqlConnection("Server=tcp:monge.database.windows.net,1433;Initial Catalog=TicketApplication;Persist Security Info=False;User ID=mongeAdmin;Password=1080aLMQP;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {

                    var command = new SqlCommand("INSERT INTO Status (name) VALUES (@name)", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("name", status.Name));
                    connection.Open();
                    command.ExecuteReader();
                    connection.Close();
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
