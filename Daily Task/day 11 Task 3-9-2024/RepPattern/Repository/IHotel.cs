using RepoPatternAssignment.Models;

namespace RepoPatternAssignment.Repository
{
    public interface IHotel
    {
        IEnumerable<HotelModel> GetAll();

        void AddHotel(HotelModel hotel);
    }
}
