using backend.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalsController : ControllerBase
    {
        private readonly IProposalActions proposalActions;
        private readonly IConfiguration configuration;

        public ProposalsController(IProposalActions proposalActions, IConfiguration configuration)
        {
            this.proposalActions = proposalActions;
            this.configuration = configuration;
        }

        // GET: api/<ProposalsController>/AAAAs
        [HttpGet]
        public async Task<IEnumerable<Proposal>> Get()
        {
            return await proposalActions.GetProposalsAsync(configuration);
        }


        // POST api/<ProposalsController  >
        [HttpPost]
        public async void Post(int proposalId, int oldFacilityId, int newFacilityId)
        {
            await proposalActions.UpdateProposalFacility(proposalId, oldFacilityId, newFacilityId, configuration);
        }

    }
}
