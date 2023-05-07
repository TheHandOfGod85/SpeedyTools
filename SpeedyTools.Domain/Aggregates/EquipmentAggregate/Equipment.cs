
namespace SpeedyTools.Domain.Aggregates.EquipmentAggregate
{
    public class Equipment
    {
        private Equipment()
        {
            
        }
        public Guid EquipmentId { get; private set; }
        public string SerialNumber { get; private set; } 
        public string Department { get; private set; }




        // factory methods
        public static Equipment CreateEquipment(string serialNumber, string department)
        {
            var equipment = new Equipment
            {
                EquipmentId = Guid.NewGuid(),
                SerialNumber = serialNumber,
                Department = department
            };

            return equipment;
        }

    }
    
}
