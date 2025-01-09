using Shared.Models;
using Shared.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserService.Services
{
    public class UserService : IService<User>
    {
        private readonly IReeepositry<User> _repository;

        public UserService(IRepository<User> rerpository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<User> GetByIdAsync(string id) => await _repository.GetByIdAsync(id);

        public async Task<User> CreatAsync(User entity) => await _repository.CreateAsync(entity);

        public async Task UpdateAsync(string id, User entity) => await _repository.UpdateAsync(id, entity);

        public async Task DeleteAsync(string id) => await _repository.DeleteAsync(id);
    }

}