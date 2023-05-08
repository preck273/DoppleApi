#nullable disable

namespace DoppleApi.Entities
{
    public partial class Testresult
    {
        public int TestId { get; set; }
        public string Result { get; set; }
        public string Reason { get; set; }
        public string OperatorCompanyId { get; set; }

        public virtual Operator OperatorCompany { get; set; }
        public virtual Test Test { get; set; }
    }
}
