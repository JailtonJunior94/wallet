using Microsoft.Azure.Cosmos;

namespace User.Infra.Repositories
{
    public class BaseRepository
    {
        private readonly CosmosClient _client;
        protected readonly Container _container;

        public BaseRepository(string databaseName, string containerName)
        {
            _client = new CosmosClient("AccountEndpoint=https://wallet-account.documents.azure.com:443/;AccountKey=nbGQ9oWGpr1ENo1zw3rhJSvDCA8F3Tc8EeSeQA1QnhiDGNCOuTSUaqPAvLMijIuh1tf5K792VqpJ5fhEGK7HMg==;");
            _container = _client.GetContainer(databaseName, containerName);
        }
    }
}
