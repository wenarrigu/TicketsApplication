using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TicketsCoreApplication.Model;

namespace TicketsCoreApplication.Repositories.Implementations
{
    public class TicketsRepository : ITicketsRepository
    {
        
        public Ticket find(int ticketNumber)
        {
            Ticket ticket = new Ticket();
            try
            {
                using (var connection = new SqlConnection("Server=tcp:monge.database.windows.net,1433;Initial Catalog=TicketApplication;Persist Security Info=False;User ID=mongeAdmin;Password=1080aLMQP;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    var command = new SqlCommand(@"SELECT 
	                                                    T.number        ,
	                                                    T.description    ,
	                                                    T.status 		  ,
	                                                    S.name			'statusName',
	                                                    T.category 	  ,
	                                                    C.description 'categoryDescription',
	                                                    T.creationDate  ,
	                                                    T.lastUpdate 	  ,
	                                                    T.comment		 
                                                    FROM Ticket T
	                                                    INNER JOIN Status S
		                                                    ON S.id = T.status
	                                                    INNER JOIN Category C
		                                                    ON C.id = T.category
                                                    WHERE number = @number
                                                    ", connection);
                    command.Parameters.Add(new SqlParameter("number", ticketNumber ));
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ticket = new Ticket()
                            {
                                TicketNumber = (int)reader["number"],
                                Description = reader["description"].ToString(),
                                Status = new Model.Status()
                                {
                                    Code = (int)reader["status"],
                                    Name = reader["statusName"].ToString()
                                },
                                Category = new Category()
                                {
                                    Code = (int)reader["category"],
                                    Description = reader["categoryDescription"].ToString()
                                },
                                Comment = reader["comment"].ToString(),
                                CreationDate = DateTime.Parse(reader["creationDate"].ToString()),
                                LastUpdateDate = DateTime.Parse(reader["lastUpdate"].ToString()),
                            };
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }

            return ticket;
        }

        public List<Ticket> findAll()
        {
            List<Ticket> tickets = new List<Ticket>();
            try
            {
                using (var connection = new SqlConnection("Server=tcp:monge.database.windows.net,1433;Initial Catalog=TicketApplication;Persist Security Info=False;User ID=mongeAdmin;Password=1080aLMQP;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    var command = new SqlCommand(@"SELECT 
	                                                    T.number        ,
	                                                    T.description    ,
	                                                    T.status 		  ,
	                                                    S.name			'statusName',
	                                                    T.category 	  ,
	                                                    C.description 'categoryDescription',
	                                                    T.creationDate  ,
	                                                    T.lastUpdate 	  ,
	                                                    T.comment		 
                                                    FROM Ticket T
	                                                    INNER JOIN Status S
		                                                    ON S.id = T.status
	                                                    INNER JOIN Category C
		                                                    ON C.id = T.category
                                                    ", connection);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tickets.Add(new Ticket()
                            {
                                TicketNumber = (int)reader["number"],
                                Description = reader["description"].ToString(),
                                Status = new Model.Status()
                                {
                                    Code = (int)reader["status"],
                                    Name = reader["statusName"].ToString()
                                },
                                Category = new Category()
                                {
                                    Code = (int)reader["category"],
                                    Description = reader["categoryDescription"].ToString()
                                },
                                Comment = reader["comment"].ToString(),
                                 CreationDate = DateTime.Parse(reader["creationDate"].ToString()),
                                LastUpdateDate = DateTime.Parse(reader["lastUpdate"].ToString()),
                            });
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }

            return tickets;
        }

        public int upsert(Ticket ticket)
        {
            int newTicketNumber = 0;
            try
            {
                using (var connection = new SqlConnection("Server=tcp:monge.database.windows.net,1433;Initial Catalog=TicketApplication;Persist Security Info=False;User ID=mongeAdmin;Password=1080aLMQP;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {

                    var command = new SqlCommand("UpsertTicket", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("number", ticket.TicketNumber));
                    command.Parameters.Add(new SqlParameter("description", ticket.Description));
                    command.Parameters.Add(new SqlParameter("status", ticket.Status.Code));
                    command.Parameters.Add(new SqlParameter("category", ticket.Category.Code));
                    command.Parameters.Add(new SqlParameter("comment", ticket.Comment));
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            newTicketNumber = int.Parse(reader["TicketNumber"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return newTicketNumber;
        }
    }
}
