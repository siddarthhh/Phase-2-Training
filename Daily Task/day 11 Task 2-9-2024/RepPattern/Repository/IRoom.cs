using RepoPatternAssignment.Models;

namespace RepoPatternAssignment.Repository
{
    public interface IRoom
    {
        IEnumerable<RoomModel> GetAll();
        void AddRoom(RoomModel room);

    }
}
