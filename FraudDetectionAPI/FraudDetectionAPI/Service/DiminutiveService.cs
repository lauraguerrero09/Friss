using FraudDetectionAPI.TableStorage;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FraudDetectionAPI.Service
{
    public class DiminutiveService : IDiminutiveService
    {
        private const string TableName = "Diminutive";
        private readonly IConfiguration _configuration;
        public DiminutiveService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<DiminutiveEntity> RetrieveAsync(string name)
        {
            var retrieveOperation = TableOperation.Retrieve<DiminutiveEntity>(name, name);
            return await ExecuteTableOperation(retrieveOperation) as DiminutiveEntity;
        }
        public async Task<DiminutiveEntity> InsertOrMergeAsync(DiminutiveEntity entity)
        {
            var insertOrMergeOperation = TableOperation.InsertOrMerge(entity);
            return await ExecuteTableOperation(insertOrMergeOperation) as DiminutiveEntity;
        }
        public async Task<DiminutiveEntity> DeleteAsync(DiminutiveEntity entity)
        {
            var deleteOperation = TableOperation.Delete(entity);
            return await ExecuteTableOperation(deleteOperation) as DiminutiveEntity;
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

    public interface IDiminutiveService
    {
        Task<DiminutiveEntity> RetrieveAsync(string name);
        Task<DiminutiveEntity> InsertOrMergeAsync(DiminutiveEntity entity);
        Task<DiminutiveEntity> DeleteAsync(DiminutiveEntity entity);
    }


}
