#nullable disable

namespace DoppleApi.Entities
{
    public partial class Order
    {
        public Order()
        {
            Carriers = new HashSet<Carrier>();
            Tests = new HashSet<Test>();
        }

        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string FaceplateText { get; set; }
        public float EarshellSize { get; set; }
        public string EarshellColor { get; set; }
        public string CradleColor { get; set; }
        public string StatusOrder { get; set; }

        public virtual ICollection<Carrier> Carriers { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
