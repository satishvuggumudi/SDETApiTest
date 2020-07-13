using Newtonsoft.Json;

namespace APIServices.ResponseModels
{
    public class Car
    {

        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("zeroToSixty")]
        public decimal ZeroToSixty { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }
    }
}
