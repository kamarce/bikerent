using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BikeRent.Model;
using BikeRentStartup.Repositories.Interfaces;

namespace BikeRentStartup.Repositories.Classes
{
    class UserRepository: IUserRepository, IDisposable

    {
        private BikeRentContext context;

        public UserRepository(BikeRentContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserByID(int id)
        {
            return context.Users.Find(id);
        }

        public void InsertUser(User student)
        {
            context.Users.Add(student);
        }

        public void DeleteUser(int studentID)
        {
            User student = context.Users.Find(studentID);
            context.Users.Remove(student);
        }

        public void UpdateUser(User student)
        {
            context.Entry(student).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

