
namespace backend.Model
{
    /// <summary>
    /// Defined in order to allow mockups to be written for unit tests
    /// </summary>
    public interface IFacilityActions
    {
        Task<Facility> GetFacilityAsync(int id, IConfiguration config);

    }
}