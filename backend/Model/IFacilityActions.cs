
namespace backend.Model
{
    public interface IFacilityActions
    {
        Task<Facility> GetFacilityAsync(int id, IConfiguration config);

    }
}