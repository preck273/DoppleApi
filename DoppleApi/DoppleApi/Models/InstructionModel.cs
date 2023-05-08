using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoppleApi.Models
{

    public class InstructionModel
    {
        [Key]
        public string InstructionId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        [ForeignKey("StationId")]
        public int StationId { get; set; }
       
        //public virtual StationModel Station { get; set; }

    }
}
