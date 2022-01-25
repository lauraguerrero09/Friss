using FraudDetectionAPI.TableStorage;
namespace FraudDetectionAPI.Model
{
    /// <summary>
    /// Used by Matching calculator controller to return the matching result
    /// </summary>
    public class MatchingResponse
    {
        public Person Person1 { get; set; }
        public Person Person2 { get; set; }
        public int Result { get; set; }
    }
}
