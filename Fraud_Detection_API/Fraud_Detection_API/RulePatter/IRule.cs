using Fraud_Detection_API.Model;
using System.Threading.Tasks;

namespace Fraud_Detection_API.RulePatter
{
    public interface IRule
    {
        public int CalculateMaching(Person person1, Person person2);
    }
}
