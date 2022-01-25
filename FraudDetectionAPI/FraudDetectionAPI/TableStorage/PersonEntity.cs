using FraudDetectionAPI.Model;
using Microsoft.Azure.Cosmos.Table;
using System;

namespace FraudDetectionAPI.TableStorage
{
    public class PersonEntity : TableEntity
    {
        public PersonEntity(string lastName, string firstName)
        {
            this.PartitionKey = lastName; this.RowKey = firstName;
        }
        public PersonEntity() { }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public string DateOfBirth { get; set; }
        public static PersonEntity Map(Person person) 
        {
            return new PersonEntity
            {
                FirstName = person.FirstName.ToLower(),
                LastName = person.LastName.ToLower(),
                IdentificationNumber = person.IdentificationNumber,
                DateOfBirth = person.DateOfBirth,
                PartitionKey = $"{person.FirstName}.{person.LastName}",
                RowKey = $"{person.FirstName}.{person.LastName}"
            };        
        }
    }
}
