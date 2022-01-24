using FraudDetectionAPI.Service;
using System.Threading.Tasks;

namespace FraudDetectionAPI.Model.Rules
{
    public class SimilarFirstName : IRule
    {
        private ITableStorageService _storageService;
        const int MatchingValue = 15;


        public SimilarFirstName(ITableStorageService storageService)
        {
            _storageService = storageService;
        }

        public int CalculateMaching(Person person1, Person person2)
        {
            if (SameInitials(person1.FirstName, person2.FirstName) > 0)
            {
                return MatchingValue;
            }

            if (HasDiminutiveNameAsync(person1.FirstName, person2.FirstName).Result > 0)
            {
                return MatchingValue;
            }

            if (HasPossibleTypo(person1.FirstName, person2.FirstName) > 0)
            {
                return MatchingValue;
            }

            return 0;
        }
        private static int SameInitials(string firstName1, string firstName2)
        {
            return firstName1[0] == firstName2[0] ? 15 : 0;
        }
        private async Task<int> HasDiminutiveNameAsync(string firstName1, string firstName2)
        {
            var result = await _storageService.RetrieveAsync(firstName1);

            if (result == null)
            {
                return 0;
            }

            return firstName2 == result.Diminutive ? 15 : 0;
        }
        private static int HasPossibleTypo(string firstName1, string firstName2)
        {
            var distance = Fastenshtein.Levenshtein.Distance(firstName1, firstName2);
            return distance == 1 ? 1 : 0;
        }
    }
}
