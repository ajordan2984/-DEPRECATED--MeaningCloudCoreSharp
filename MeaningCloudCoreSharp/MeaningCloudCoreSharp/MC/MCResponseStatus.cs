using Newtonsoft.Json;
namespace MeaningCloudCoreSharp.MC
{
    public class MCResponseStatus
    {
        [JsonProperty("code")]
        public string code { get; set; }

        [JsonProperty("msg")]
        public string msg { get; set; }

        /// <summary>
        /// Contains a natural number that indicates the credits consumed in the request.
        /// 
        /// A request is any HTTP request done to the API to analyze less than 500 words. 
        /// If the text sent is longer than that, then it will be considered that more than a request is made, 
        /// more specifically, as many requests as we would need if the text were divided in chunks of 500 words.
        /// For instance, an HTTP request with 1013 words, will count as three requests, so 3 credits will be consumed; 
        /// an HTTP request with a text 25648 words long would count as 25648/500 = 51.296 => 52 credits, and so on.
        /// </summary>
        [JsonProperty("credits")]
        public string credits { get; set; }

        /// <summary>
        /// Contains a natural number that indicates the number of credits left to the user to get to the credit limit.
        /// </summary>
        [JsonProperty("remaining_credits")]
        public string remaining_credits { get; set; }
    }
}
