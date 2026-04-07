using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DTO.ForecastDtos
{
    public class ForecastDayDto
    {
        public DateTime Date { get; set; }

        [JsonProperty("date_epoch")]
        public long DateEpoch { get; set; }

        public DayDto Day { get; set; }

        public AstroDto Astro { get; set; }

        [JsonProperty("hour")]
        public List<HourDto> Hours { get; set; }
    }
}
