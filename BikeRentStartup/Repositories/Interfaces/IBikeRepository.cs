using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeRent.Model;

//napravljeno po uzoru na https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
namespace BikeRentStartup.Repositories.Interfaces
{
    interface IBikeRepository
    {

        IEnumerable<Bike> GetBikes();
        Bike GetBikeByID(int bikeId);
        void InsertBike(Bike bike);
        void DeleteBike(int bikeID);
        void UpdateBike(Bike bike);
        void Save();
    }
}
