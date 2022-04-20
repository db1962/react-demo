using backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityActions facilityActions;
        private readonly IConfiguration configuration;

        public FacilityController(IFacilityActions facilityActions, IConfiguration configuration)
        {
            this.facilityActions = facilityActions;
            this.configuration = configuration;
        }

        // GET api/<ProposalsController>/5
        [HttpGet("{id}", Name = "Proposal Id")]
        public async Task<Facility> GetFacility(int id)
        {

            try
            {
                return await facilityActions.GetFacilityAsync(id, configuration);
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 400;
                // add some logging here
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
