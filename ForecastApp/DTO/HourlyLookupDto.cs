using System.Collections.Generic;

namespace DTO
{
    public class HourlyLookupDto : BaseLookupDto
    {
        public static HourlyLookupDto Error(string errorMessage) => new HourlyLookupDto
        {
            Status = 500,
            Message = errorMessage,
            Data = new List<HourDto>()
        };

        public List<HourDto> Data { get; set; }
    }
}
