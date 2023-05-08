using System.ComponentModel.DataAnnotations;

namespace DoppleApi.Models
{
    public class CarrierModel
    {
        [Key]
        /// <summary>
        /// cool andgood
        /// </summary>
        public string TagId { get; set; }
        [Required]
        public string OrderIdO { get; set; }
        [Required]
        public int StationId { get; set; }
        [Required]
        public string StatusCarrier { get; set; }

        // public virtual Order OrderIdONavigation { get; set; }
        //public virtual Station Station { get; set; }
        // public virtual ICollection<Test> Tests { get; set; }
    }
}
