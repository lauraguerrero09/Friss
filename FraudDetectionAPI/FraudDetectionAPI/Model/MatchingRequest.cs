using System.ComponentModel.DataAnnotations;

namespace FraudDetectionAPI.Model
{
    /// <summary>
    /// Used by Martching calculator controller to receive person to compared
    /// </summary>
    public class MatchingRequest
    {
        [Required(ErrorMessage = "Person 1 is required")]
        public Person Person1 { get; set; }

        [Required(ErrorMessage = "Person 2 is required")]
        public Person Person2 { get; set; }
    }
}
