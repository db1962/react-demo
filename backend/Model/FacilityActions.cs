using backend.Exceptions;
using System.Data.SqlClient;

namespace backend.Model
{
    public class FacilityActions : IFacilityActions
    {
        public async Task<Facility> GetFacilityAsync(int id, IConfiguration config)
        {
            using (SqlConnection con = new SqlConnection(config.GetConnectionString("Database")))
            {
                using (SqlCommand cmd = new SqlCommand())
                {                                  
                    cmd.CommandText = "GetFacility";
                    cmd.Parameters.AddWithValue("proposalId", id);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = con;
                    await con.OpenAsync();
                    var reader = await cmd.ExecuteReaderAsync();

                    if (!reader.HasRows) throw new ReaderNoRowsFoundException("No rows associated with the criteria");
                    var facility = new Facility();
                    while (reader.Read())
                    {                        
                        facility.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        facility.Currency = reader.GetString(reader.GetOrdinal("Currency"));
                        facility.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                        facility.FacilityName = reader.GetString(reader.GetOrdinal("FacilityName"));
                        facility.ProposalId = reader.GetInt32(reader.GetOrdinal("ProposalId"));
                        facility.BookingCountry = reader.GetString(reader.GetOrdinal("BookingCountry"));
                        facility.MaturityDate = reader.GetDateTime(reader.GetOrdinal("MaturityDate"));
                    }
                   
                    return facility;
                }
            }
        }
    }
}
