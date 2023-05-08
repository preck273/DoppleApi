#nullable disable

namespace DoppleApi.Entities
{
    public partial class Operator
    {
        public string OperatorId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Authorization { get; set; }

        public virtual Operatorposition Operatorposition { get; set; }
        public virtual Testresult Testresult { get; set; }
    }
}
