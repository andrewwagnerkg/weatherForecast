
using System;
using Newtonsoft.Json;

namespace DTO.ForecastDtos
{
    public class LocationDto
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        public DateTime LocalTime { get; set; }

    }
}
