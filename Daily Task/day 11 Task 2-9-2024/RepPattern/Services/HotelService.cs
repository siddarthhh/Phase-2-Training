using Microsoft.EntityFrameworkCore;
using RepoPatternAssignment.Models;
using RepoPatternAssignment.Repository;

namespace RepoPatternAssignment.Services
{
    public class HotelService : IHotel
    {
        private readonly HotelDbContext _context;

        public HotelService (HotelDbContext context)
        {
            _context = context;
        }

        public IEnumerable <HotelModel> GetAll()
        {
            return _context.Hotels.Include(o=>o.Room).ToList();
        }
        public void AddHotel(HotelModel hotel)
        {
            _context.Add(hotel);
            _context.SaveChanges();
        }
    }
}
