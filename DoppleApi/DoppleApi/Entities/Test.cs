#nullable disable

namespace DoppleApi.Entities
{
    public partial class Test
    {
        public string TagId { get; set; }
        public int TestId { get; set; }
        public string OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Carrier Tag { get; set; }
        public virtual Testresult Testresult { get; set; }
    }
}
