using Microsoft.Azure.Cosmos.Table;

namespace Fraud_Detection_API.TableStorage
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
