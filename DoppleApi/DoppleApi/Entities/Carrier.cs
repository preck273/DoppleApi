#nullable disable

namespace DoppleApi.Entities
{
    public partial class Carrier
    {
        public Carrier()
        {
            Tests = new HashSet<Test>();
        }

        public string TagId { get; set; }
        public string OrderIdO { get; set; }
        public int StationId { get; set; }
        public string StatusCarrier { get; set; }

        public virtual Order OrderIdONavigation { get; set; }
        public virtual Station Station { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
