using System.ComponentModel.DataAnnotations;

namespace DoppleApi.Models
{
    public class TurnOverTimeModel
    {
        [Key]
        public string OrderId { get; set; }
        [Key]
        public int StationId { get; set; }
        
        public DateTime DateStart { get; set; }
        
        public TimeSpan TimeStart { get; set; }
        
        public TimeSpan TimeEnd { get; set; }

        //public virtual Order Order { get; set; }
        //public virtual Station Station { get; set; }
    }
}
