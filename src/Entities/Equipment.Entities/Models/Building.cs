using System.Collections.Generic;

namespace Equipment.Entities.Models
{
    public class Building
    {
        public int BuildingId { get; set; }

        public string Name { get; set; }

        public ICollection<Room> Rooms { get; private set; }
    }
}
