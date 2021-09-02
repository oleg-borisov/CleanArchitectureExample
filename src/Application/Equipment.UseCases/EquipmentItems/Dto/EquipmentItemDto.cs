namespace Equipment.UseCases.EquipmentItems.Dto
{
    public class EquipmentItemDto
    {
        public int EquipmentItemId { get; set; }

        public int EquipmentTypeId { get; set; }

        public int RoomId { get; set; }

        public int Quantity { get; set; }
    }
}
