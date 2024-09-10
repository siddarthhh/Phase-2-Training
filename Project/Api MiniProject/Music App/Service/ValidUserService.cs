using MusicApp.Interface;
using MusicApp.Models;
using MusicApp.Repository;

namespace MusicApp.Service
{
    public class ValidUserService
    {

        private readonly IValidUser _repository;

        public ValidUserService(IValidUser repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ValidUser>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ValidUser> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<ValidUser> AddAsync(ValidUser validUser)
        {
            return await _repository.AddAsync(validUser);
        }

        public async Task<ValidUser> UpdateAsync(int id, ValidUser validUser)
        {
            if (id != validUser.UserId)
            {
                return null; // You might want to throw an exception here
            }

            return await _repository.UpdateAsync(validUser);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);
        }
    }
}
