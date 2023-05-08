using System.ComponentModel.DataAnnotations;

namespace DoppleApi.Models
{
    public class TestModel
    {
        [Required]
        public string TagId { get; set; }
        [Key]
        public int TestId { get; set; }
        [Required]
        public string OrderId { get; set; }

        // public virtual Order Order { get; set; }
        //  public virtual Carrier Tag { get; set; }
        // public virtual Testresult Testresult { get; set; }
    }
}
