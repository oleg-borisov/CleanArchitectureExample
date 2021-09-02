using System.Collections.Generic;

namespace Equipment.Entities.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        public int BuildingId { get; set; }

        public string Name { get; set; }


        public Building Building { get; set; }

        public ICollection<EquipmentItem> EquipmentItems { get; private set; }
    }
}
