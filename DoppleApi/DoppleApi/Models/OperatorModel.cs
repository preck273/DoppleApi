using System.ComponentModel.DataAnnotations;

namespace DoppleApi.Models
{
    public class OperatorModel
    {
        [Key]
        public string OperatorId { get; set; }
        [Required] 
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Authorization { get; set; }

        //public virtual Operatorposition Operatorposition { get; set; }
        //  public virtual Testresult Testresult { get; set; }
    }
}
