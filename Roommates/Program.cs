using System;
using System.Collections.Generic;
using Roommates.Models;
using Roommates.Repositories;

namespace Roommates
{
    class Program
    {
        /// <summary>
        ///  This is the address of the database.
        ///  We define it here as a constant since it will never change.
        /// </summary>
        private const string CONNECTION_STRING = @"server=localhost\SQLExpress;database=Roommates;integrated security=true";

        static void Main(string[] args)
        {
            RoomRepository roomRepo = new RoomRepository(CONNECTION_STRING);

            Console.WriteLine("Getting All Rooms:");
            Console.WriteLine();

            List<Room> allRooms = roomRepo.GetAll();

            foreach (Room room in allRooms)
            {
                Console.WriteLine($"{room.Name} has an Id of {room.Id} and a max occupancy of {room.MaxOccupancy}");
            }

            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Room with Id 1");

            Room singleRoom = roomRepo.GetById(1);

            Console.WriteLine($"Single room ID: {singleRoom.Id} Single room name: {singleRoom.Name} Single room occupancy: {singleRoom.MaxOccupancy}");

            Room bathroom = new Room
            {
                Name = "Bathroom",
                MaxOccupancy = 1
            };

            roomRepo.Insert(bathroom);

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Added the new Room with id {bathroom.Id}");

            Room updatedRoom = new Room
            {
                Name = "Front Room",
                MaxOccupancy = 5,
                Id = 1
            };

            roomRepo.Update(updatedRoom);

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Updated front room, occupancy is now: {updatedRoom.MaxOccupancy}");

            roomRepo.Delete(2);

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Deleted back bedroom");

            RoommateRepository roommateRepo = new RoommateRepository(CONNECTION_STRING);

            Console.WriteLine("Getting Roommates by Room Id:");
            Console.WriteLine();

            List<Roommate> allRoommates = roommateRepo.GetRoommatesByRoomId(1);

            foreach (Roommate roommate in allRoommates)
            {
                Console.WriteLine($"{roommate.FirstName}");
            }

        }
    }
}
