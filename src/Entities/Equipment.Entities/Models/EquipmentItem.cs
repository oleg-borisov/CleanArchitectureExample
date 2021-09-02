namespace Equipment.Entities.Models
{
    public class EquipmentItem
    {
        public int EquipmentTypeId { get; set; }

        public int RoomId { get; set; }

        public int Quantity { get; set; }

        
        public Room Room { get; set; }

        public EquipmentType EquipmentType { get; set; }
    }
}
