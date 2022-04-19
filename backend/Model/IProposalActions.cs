
namespace backend.Model
{
    public interface IProposalActions
    {
        // Task<List<Proposal>> GetProposalAsync(int id, IConfiguration config);
        Task<List<Proposal>> GetProposalsAsync(IConfiguration config);

        Task<bool> UpdateProposalFacility(int proposalId, int oldFacilityId, int newFacilityId, IConfiguration config);
    }
}