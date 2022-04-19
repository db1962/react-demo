using System.Configuration;
using System.Data.SqlClient;

namespace backend.Model
{
    public class ProposalActions : IProposalActions
    {
        public async Task<List<Proposal>> GetProposalsAsync(IConfiguration config)
        {
            using (SqlConnection con = new SqlConnection(config.GetConnectionString("Database")))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "GetProposals";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = con;
                    await con.OpenAsync();
                    var reader = await cmd.ExecuteReaderAsync();
                    var result = new List<Proposal>();
                    
                    while (reader.Read())
                    {
                        Proposal proposal = new Proposal();
                        proposal.ProposalStatus = reader.GetString(reader.GetOrdinal("Status"));
                        proposal.CustomerGrpName = reader.GetString(reader.GetOrdinal("CustomerGrpName"));
                        proposal.ProposalName = reader.GetString(reader.GetOrdinal("ProposalName"));
                        proposal.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        proposal.Date = reader.GetDateTime(reader.GetOrdinal("Date"));
                        proposal.Description = reader.GetString(reader.GetOrdinal("Description"));
                        result.Add(proposal);
                    }

                    return result;
                }
            }
        }

        public async Task<bool> UpdateProposalFacility(int proposalId, int oldFacilityId, int newFacilityId, IConfiguration config)
        {
            using (SqlConnection con = new SqlConnection(config.GetConnectionString("Database")))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "UpdateProposalFacility";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = con;
                    await con.OpenAsync();
                    var result = await cmd.ExecuteNonQueryAsync();
                    return result != 0;
                }
            }
        }
    }
}
