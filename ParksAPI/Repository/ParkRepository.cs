using ParksAPI.Interfaces;
using ParksAPI.Models;

namespace ParksAPI.Repository
{
    public class ParkRepository : RepositoryBase<Park>, IParkRepository
    {
        public ParkRepository(ParksAPIContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public PagedList<Park> GetParks(PagedParameters parkParameters)
        {
            return PagedList<Park>.ToPagedList(FindAll(),
                parkParameters.PageNumber,
                parkParameters.PageSize);
        }

        public Park GetParkById(Guid parkId)
        {
            return FindByCondition(park => park.ParkId.Equals(parkId))
                .DefaultIfEmpty(new Park())
                .FirstOrDefault();
        }

    }
}