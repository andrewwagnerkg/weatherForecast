using System.Collections.Generic;

namespace DTO
{
    public class DailyLookupDto : BaseLookupDto
    {
        public static DailyLookupDto Error(string errorMessage) => new DailyLookupDto
        {
            Status = 500,
            Message = errorMessage,
            Data = new List<DailyDto>()
        };

        public List<DailyDto> Data { get; set; }
    }
}
