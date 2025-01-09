using Microsoft.Azure.Cosmos;
using shared.Models;
using shared.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserService.Repoitories
{
    public class UserRepository : IRepository<User>
    {
        private readonly Container _container;

        public UserRepository (CosmosClient cosmosClient, string databaseId, string containerId)
        {
            _container = cosmosClient.GetContainer(databaseId, containerId);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var query = _container.GetItemQueryIterator<User>();
            var results = new List<User>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }

        public async Task<User> GetByIdAsync(string id) => await _container.ReadItemAsync<User>(id, new PartitionKey(id));
        
        public async Task<User> CreateAsync(User entity) => await _container.CreateItemAsync(entity, new PartitionKey(entity.Id));

        public async Task UpdateAsync(string id, User entity) => await _container.UpsertItemAsync(entity, new PartitionKey(id));

        public async Task DeleteAsync(string id) => await _container.DeleteItemAsync<User>(id, new PartitionKey(id));

    }
}