using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace FraudDetectionAPI.Model
{
    public class Person
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName
        {
            get; set;
        }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName {
            get; set;
        }
        [RegularExpression(@"(\d{2}/\d{2}/\d{4})", ErrorMessage = "DateOfBirth Invalid format DD/MM/YYYY")]
        public string DateOfBirth { get; set; }
        public string IdentificationNumber { get; set; }
    }
}
