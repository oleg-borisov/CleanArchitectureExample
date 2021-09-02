using Equipment.DataAccess.Interfaces;
using Equipment.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Equipment.DataAccess.Implementation.MSSQL
{
    public class ApplicationDBContext : DbContext, IDBContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
        }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<EquipmentType> EquipmentTypes { get; set; }

        public DbSet<EquipmentItem> EquipmentItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EquipmentItem>().HasKey(x => new 
            { 
                x.EquipmentTypeId, 
                x.RoomId 
            });

            modelBuilder.Entity<Building>().HasData(new List<Building>
            {
                new Building
                {
                    BuildingId = 1,
                    Name = "Административное здание"
                },
                new Building
                {
                    BuildingId = 2,
                    Name = "Транспортный цех"
                }
            });

            modelBuilder.Entity<Room>().HasData(new List<Room> 
            { 
                new Room
                {
                    RoomId = 1,
                    Name = "Серверная",
                    BuildingId = 1
                },
                new Room
                {
                    RoomId = 2,
                    Name = "Приёмная",
                    BuildingId = 1
                },
                new Room
                {
                    RoomId = 3,
                    Name = "Бухгалтерия",
                    BuildingId = 1
                },
                new Room
                {
                    RoomId = 4,
                    Name = "Кабинет директора",
                    BuildingId = 1
                },
                new Room
                {
                    RoomId = 5,
                    Name = "Автомастерская",
                    BuildingId = 2
                },
                new Room
                {
                    RoomId = 6,
                    Name = "Гараж",
                    BuildingId = 2
                },
                new Room
                {
                    RoomId = 7,
                    Name = "Кладовая",
                    BuildingId = 2
                }
            });

            modelBuilder.Entity<EquipmentType>().HasData(new List<EquipmentType>
            {
                new EquipmentType
                {
                    EquipmentTypeId = 1,
                    Name = "Сервер"
                },
                new EquipmentType
                {
                    EquipmentTypeId = 2,
                    Name = "Клавиатура"
                },
                new EquipmentType
                {
                    EquipmentTypeId = 3,
                    Name = "Мышка"
                },
                new EquipmentType
                {
                    EquipmentTypeId = 4,
                    Name = "Ноутбук"
                },
            });

            modelBuilder.Entity<EquipmentItem>().HasData(new List<EquipmentItem>
            {
                new EquipmentItem
                {
                    EquipmentTypeId = 1,
                    RoomId = 1,
                    Quantity = 1
                },
                new EquipmentItem
                {
                    EquipmentTypeId = 2,
                    RoomId = 1,
                    Quantity = 1
                },
                new EquipmentItem
                {
                    EquipmentTypeId = 3,
                    RoomId = 1,
                    Quantity = 1
                },
                new EquipmentItem
                {
                    EquipmentTypeId = 4,
                    RoomId = 4,
                    Quantity = 1
                },
                new EquipmentItem
                {
                    EquipmentTypeId = 3,
                    RoomId = 4,
                    Quantity = 1
                },
            });
        }
    }
}
