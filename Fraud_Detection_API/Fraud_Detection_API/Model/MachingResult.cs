using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fraud_Detection_API.Model
{
    public class MachingResult
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public int MatchingPercentage { get; set; }
    }
}
