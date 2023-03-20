
namespace TicketSystem.Application.Common.Models
{
    public class CustomError
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
    }
}
