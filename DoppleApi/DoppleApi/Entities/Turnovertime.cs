#nullable disable

namespace DoppleApi.Entities
{
    public partial class Turnovertime
    {
        public string OrderId { get; set; }
        public int StationId { get; set; }
        public DateTime DateStart { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }

        public virtual Order Order { get; set; }
        public virtual Station Station { get; set; }
    }
}
