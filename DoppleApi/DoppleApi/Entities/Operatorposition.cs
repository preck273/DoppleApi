#nullable disable

namespace DoppleApi.Entities
{
    public partial class Operatorposition
    {
        public string OperatorId { get; set; }
        public int StationId { get; set; }

        public virtual Operator Operator { get; set; }
        public virtual Station Station { get; set; }
    }
}
