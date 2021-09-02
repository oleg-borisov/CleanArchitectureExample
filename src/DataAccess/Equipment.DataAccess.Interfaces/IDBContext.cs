using Equipment.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Equipment.DataAccess.Interfaces
{
    public interface IDBContext
    {
        DbSet<Building> Buildings { get; }

        DbSet<Room> Rooms { get; }

        DbSet<EquipmentType> EquipmentTypes { get; set; }

        DbSet<EquipmentItem> EquipmentItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
