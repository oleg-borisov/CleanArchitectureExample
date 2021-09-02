using Equipment.DataAccess.Implementation.MSSQL;
using Equipment.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Equipment.UseCases.Tests.Utils
{
    public static class ApplicationContextFactory
    {
        public static ApplicationDBContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dbContext = new ApplicationDBContext(options);

            dbContext.Database.EnsureCreated();

            dbContext.Buildings.AddRange(new List<Building>
            {
                new Building
                {
                    BuildingId = 10,
                    Name = "Building 10"
                },
                new Building
                {
                    BuildingId = 11,
                    Name = "Building 11"
                }
            });

            dbContext.Rooms.AddRange(new List<Room>
            {
                new Room
                {
                    RoomId = 10,
                    Name = "Room 10",
                    BuildingId = 10
                },
                new Room
                {
                    RoomId = 11,
                    Name = "Room 11",
                    BuildingId = 10
                },
                new Room
                {
                    RoomId = 12,
                    Name = "Room 12",
                    BuildingId = 10
                },
                new Room
                {
                    RoomId = 13,
                    Name = "Room 13",
                    BuildingId = 10
                }
            });

            dbContext.EquipmentTypes.AddRange(new List<EquipmentType>
            {
                new EquipmentType
                {
                    EquipmentTypeId = 10,
                    Name = "EquipmentType 1"
                },
                new EquipmentType
                {
                    EquipmentTypeId = 11,
                    Name = "EquipmentType 2"
                }
            });

            dbContext.EquipmentItems.AddRange(new List<EquipmentItem>
            {
                new EquipmentItem
                {
                    EquipmentTypeId = 10,
                    RoomId = 10,
                    Quantity = 1
                },
                new EquipmentItem
                {
                    EquipmentTypeId = 11,
                    RoomId = 11,
                    Quantity = 100
                }
            });

            dbContext.SaveChanges();

            return dbContext;
        }
    }
}
