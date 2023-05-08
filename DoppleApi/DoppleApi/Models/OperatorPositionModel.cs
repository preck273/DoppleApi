using System.ComponentModel.DataAnnotations;
namespace DoppleApi.Models
{
    public class OperatorPositionModel
    {
        [Key]
        public string OperatorId { get; set; }
        [Required]
        public int StationId { get; set; }

        // public virtual Operator Operator { get; set; }
        // public virtual Station Station { get; set; }
    }
}
