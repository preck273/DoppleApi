using System.ComponentModel.DataAnnotations;


namespace DoppleApi.Models
{
    public class OrderModel
    {
        [Key]
        public string OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string FaceplateText { get; set; }
        [Required]
        public float EarshellSize { get; set; }
        [Required]
        public string EarshellColor { get; set; }
        [Required]
        public string CradleColor { get; set; }
        [Required]
        public string StatusOrder { get; set; }

        //public virtual StationModel Station { get; set; }


    }
}

