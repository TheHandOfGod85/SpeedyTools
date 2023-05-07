using SpeedyTools.Application.Contracts;

namespace SpeedyTools.Api.Contracts
{
    public class CreateEquipmentDto : BaseContract<CreateEquipmentCommand>
    {
        public string SerialNumber { get; set; }
        public string Department { get; set; }

        public override CreateEquipmentCommand Map()
        {
            return new CreateEquipmentCommand(SerialNumber, Department);
        }
    }
}
