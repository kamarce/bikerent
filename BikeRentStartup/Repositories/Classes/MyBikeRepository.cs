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
    class MyBikeRepository : IBikeRepository, IDisposable
     
        {
            private BikeRentContext context;

            public MyBikeRepository(BikeRentContext context)
            {
                this.context = context;
            }

            public IEnumerable<Bike> GetBikes()
            {
                return context.Bikes.ToList();
            }

            public Bike GetBikeByID(int id)
            {
                return context.Bikes.Find(id);
            }

            public void InsertBike(Bike student)
            {
                context.Bikes.Add(student);
            }

            public void DeleteBike(int studentID)
            {
                Bike student = context.Bikes.Find(studentID);
                context.Bikes.Remove(student);
            }

            public void UpdateBike(Bike student)
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

