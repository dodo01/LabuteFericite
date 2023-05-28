using System;
using Newtonsoft.Json;

namespace LabuteCalatoare.Infrastructure.Responses
{
    public class FailureResponse
    {
        public bool Success => false;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }

    }
}
