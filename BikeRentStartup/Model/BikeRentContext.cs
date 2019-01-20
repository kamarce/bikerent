
using System;


using System.Data.Entity;


namespace BikeRent.Model
{
    class BikeRentContext:DbContext
    {
            public DbSet<Bike> Bikes { get; set; }
            public DbSet<User> Users { get; set; }

            public DbSet<Rent> Rents { get; set; }

   

    }

    public class Bike
    {
        public int BikeId { get; set; }
        public string Name { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

    }


    public class Rent {

        public int RentId { get; set; }
        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }

        public bool RentActive { get; set; }

        public int BikeId { get; set; }
        public virtual Bike Bike { get; set; }

        public int UserId { get; set; }

        //virtual enables lazy loading https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/workflows/new-database
        public virtual User User {get; set;}
    }
        
}
