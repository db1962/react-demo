
namespace backend.Model
{

    /// <summary>
    /// Defined inorder to allow for mockups to be written for unit tests
    /// </summary>
    public interface IProposalActions
    {
        // Task<List<Proposal>> GetProposalAsync(int id, IConfiguration config);
        Task<List<Proposal>> GetProposalsAsync(IConfiguration config);
        Task<bool> UpdateProposalFacility(int proposalId, int oldFacilityId, int newFacilityId, IConfiguration config);
    }
}