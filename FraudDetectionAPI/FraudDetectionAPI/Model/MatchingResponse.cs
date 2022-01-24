using FraudDetectionAPI.TableStorage;
using System;

namespace FraudDetectionAPI.Model
{
    public class MatchingResponse
    {
        public Person Person1 { get; set; }

        public Person Person2 { get; set; }

        public int Result { get; set; }
    }
}
