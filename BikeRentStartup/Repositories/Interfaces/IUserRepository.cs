using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BikeRent.Model;

namespace BikeRentStartup.Repositories.Interfaces
{
    interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(int userId);
        void InsertUser(User user);
        void DeleteUser(int userID);
        void UpdateUser(User user);
        void Save();
    }
}
