using System.Collections.Generic;

namespace Equipment.Entities.Models
{
    public class EquipmentType
    {
        public int EquipmentTypeId { get; set; }

        public string Name { get; set; }

        public ICollection<EquipmentItem> EquipmentItems { get; set; }

    }
}
