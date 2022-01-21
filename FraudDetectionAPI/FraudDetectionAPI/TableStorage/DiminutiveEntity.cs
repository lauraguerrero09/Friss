using Microsoft.Azure.Cosmos.Table;

namespace FraudDetectionAPI.TableStorage
{
    public class DiminutiveEntity : TableEntity
    {
        public DiminutiveEntity(string name)
        {
            this.PartitionKey = name; 
            this.RowKey = name;
        }
        public DiminutiveEntity() { }
        public string Diminutive { get; set; }
    }
}
