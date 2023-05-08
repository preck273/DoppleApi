using System.ComponentModel.DataAnnotations;

namespace DoppleApi.Models
{
    public class TestResultModel
    {
        [Key]
        public int TestId { get; set; }
        [Required]
        public string Result { get; set; }
        [Required]
        public string Reason { get; set; }
        [Key]
        public string OperatorCompanyId { get; set; }

        // public virtual Operator OperatorCompany { get; set; }
        // public virtual Test Test { get; set; }
    }
}
