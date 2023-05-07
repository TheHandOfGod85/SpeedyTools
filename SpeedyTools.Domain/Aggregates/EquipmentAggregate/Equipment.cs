
namespace SpeedyTools.Domain.Aggregates.EquipmentAggregate
{
    public class Equipment
    {
        public Guid EquipmentId { get; private set; }
        public string SerialNumber { get; private set; } 
        public string Department { get; private set; }

    }
    
}
