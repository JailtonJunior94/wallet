using Microsoft.Azure.Cosmos;

namespace User.Infra.Repositories
{
    public class BaseRepository
    {
        private readonly CosmosClient _client;
        protected readonly Container _container;

        public BaseRepository(string databaseName, string containerName)
        {
            _client = new CosmosClient("");
            _container = _client.GetContainer(databaseName, containerName);
        }
    }
}
