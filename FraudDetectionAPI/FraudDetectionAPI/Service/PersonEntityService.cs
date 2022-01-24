using FraudDetectionAPI.TableStorage;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FraudDetectionAPI.Service
{
    public class PersonEntityService : IPersonEntityService
    {
        private const string TableName = "Person";
        private readonly IConfiguration _configuration;
        public PersonEntityService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<PersonEntity> InsertOrMergeAsync(PersonEntity entity)
        {
            var insertOrMergeOperation = TableOperation.InsertOrMerge(entity);
            return await ExecuteTableOperation(insertOrMergeOperation) as PersonEntity;
        }
       
        private async Task<object> ExecuteTableOperation(TableOperation tableOperation)
        {
            var table = await GetCloudTable();
            var tableResult = await table.ExecuteAsync(tableOperation);
            return tableResult.Result;
        }
        private async Task<CloudTable> GetCloudTable()
        {
            var storageAccount = Microsoft.Azure.Cosmos.Table.CloudStorageAccount.Parse(_configuration["StorageConnectionString"]);
            var tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            var table = tableClient.GetTableReference(TableName);
            await table.CreateIfNotExistsAsync();
            return table;
        }

    }

    public interface IPersonEntityService
    {
        Task<PersonEntity> InsertOrMergeAsync(PersonEntity personEntity);
    }
}
