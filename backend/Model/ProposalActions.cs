using backend.Exceptions;
using System.Configuration;
using System.Data.SqlClient;

namespace backend.Model
{
    public class ProposalActions : IProposalActions
    {
        /// <summary>
        /// Fetch the proposals from database.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
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

                    if (!reader.HasRows) throw new ReaderNoRowsFoundException("No rows associated with the criteria");

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

        /// <summary>
        /// Update the proposal with a new facility
        /// </summary>
        /// <param name="proposalId"></param>
        /// <param name="oldFacilityId"></param>
        /// <param name="newFacilityId"></param>
        /// <param name="config"></param>
        /// <returns></returns>
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
