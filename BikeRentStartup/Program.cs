using System;
using System.Collections.Generic;

using BikeRentStartup;
using BikeRent.Model;


using BikeRentStartup.Repositories.Interfaces;
using BikeRentStartup.Repositories.Classes;

namespace BikeRent
{
    public class Program
    {
        static void Main(string[] args)
        {
            //using (var db = new BikeRentContext())
            //{

            //    DeleteAllData(db);
            //    AddSeedData(db);

            //}


            var dbContext = new BikeRentContext();
            IBikeRepository bikeRepository = new MyBikeRepository(dbContext);

            IUserRepository userRepository = new UserRepository(dbContext);
         




            PrintAll(bikeRepository,userRepository);

            Console.ReadKey();



        }


        static void PrintAll(IBikeRepository repoBike, IUserRepository repoUser) {

            Console.WriteLine("Bikes in database\n-----------");
            foreach (var bike in repoBike.GetBikes())
            {
                Console.WriteLine("BikeId:   {0}\nBikeName: {1}\n-------", bike.BikeId, bike.Name);
            }

            Console.WriteLine("Users in database\n-----------");
            foreach (var bike in repoUser.GetUsers())
            {
                Console.WriteLine("UserId:   {0}\nUserName: {1}\n-------", bike.UserId, bike.Name);
            }

        }


       

        static void DeleteAllData(BikeRentContext dbContext)
        {
                dbContext.Database.ExecuteSqlCommand("DELETE FROM [Rents]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM [Bikes]");
                dbContext.Database.ExecuteSqlCommand("DELETE FROM [Users]");
                dbContext.SaveChanges();
        }

        static void AddSeedData(BikeRentContext dbContext )
        {
            var bikes = GetBikesSeed();
            var users = GetUsersSeed();

            //using (var dbContext = new BikeRentContext())
            //{
                dbContext.Bikes.AddRange(bikes);
                dbContext.Users.AddRange(users);
                dbContext.SaveChanges();



                var rent = new Rent
                {
                    BikeId = bikes[0].BikeId,
                    UserId = users[0].UserId,
                    RentActive = true,
                    //year, month, day, hour, minute, and second.
                    RentStart = new DateTime(2019, 1, 22, 15, 0, 0),
                    RentEnd = new DateTime(2019, 1, 22, 16, 0, 0)
                };


                dbContext.Rents.Add(rent);
                dbContext.SaveChanges();
            //}
        }

        static List<Bike> GetBikesSeed()
        {
            var bikeList = new List<Bike>()
                {
                  new Bike { Name = "Nakamura bijela" },
                  new Bike  {Name = "Nakamura crna" },
                  new Bike  {Name = "Norco Smeda" },
                  new Bike  {Name = "Sirocco muska" },
                  new Bike  {Name = "Wheeler Plava" },
                };

            return bikeList;
        }


        static List<User> GetUsersSeed()
        {
            var userList = new List<User>()
                {
                  new User { Name = "Karla",Country="Croatia"},
                  new User  {Name = "Petra" ,Country="Croatia"},
                  new User  {Name = "Andrea",Country="Croatia"},
                  new User  {Name = "Ana",Country="Croatia"},
                  new User  {Name = "Pero" ,Country="Croatia"},
                };

            return userList;
        }




    }


    

}
    

