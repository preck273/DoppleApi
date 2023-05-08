#nullable disable

namespace DoppleApi.Entities
{
    public partial class Instruction
    {
        public string InstructionId { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int StationId { get; set; }
        public virtual Station Station { get; set; }
    }

}
