using Microsoft.EntityFrameworkCore;
using RepoPatternAssignment.Models;
using RepoPatternAssignment.Repository;

namespace RepoPatternAssignment.Services
{
    public class RoomService : IRoom
    {
        private readonly HotelDbContext _context;
        public RoomService (HotelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomModel> GetAll()
        {
            return _context.Rooms.Include(o=>o.HotelModel).ToList();
        }
        public void AddRoom(RoomModel room)
        {
            _context.Add(room);
            _context.SaveChanges();
        }

    }
}
