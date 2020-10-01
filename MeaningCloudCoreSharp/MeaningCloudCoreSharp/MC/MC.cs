using Newtonsoft.Json;

namespace MeaningCloudCoreSharp.MC
{
    public class MC
    {
        [JsonProperty("status")]
        public MCResponseStatus status { get; set; }

        [JsonProperty("summary")]
        public string summary { get; set; }
    }
}
