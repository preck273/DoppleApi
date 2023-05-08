#nullable disable

namespace DoppleApi.Entities
{
    public partial class Station
    {
        public Station()
        {
            Carriers = new HashSet<Carrier>();
            Operatorpositions = new HashSet<Operatorposition>();
        }

        public int StationId { get; set; }
        public string StatusStation { get; set; }

        public virtual Instruction Instruction { get; set; }
        public virtual ICollection<Carrier> Carriers { get; set; }
        public virtual ICollection<Operatorposition> Operatorpositions { get; set; }

       
    }
}
