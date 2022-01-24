using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace FraudDetectionAPI.Model
{
    public class Person
    {
        [BindRequired]
        public string FirstName { get; set; }
        [BindRequired]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentificationNumber { get; set; }
    }
}
