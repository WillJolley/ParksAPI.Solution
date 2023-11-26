using ParksAPI.Models;

namespace ParksAPI.Interfaces
{
  public interface IParkRepository : IRepositoryBase<Park>
  {
    PagedList<Park> GetParks(PagedParameters parkParameters);
    Park GetParkById(Guid parkId);
  }
}