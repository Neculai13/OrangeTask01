using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Entities;
using Domain.Repository.Interfaces;

namespace Domain.Repository
{
    public class AppointmentRepository:IAppointmentRepository
    {
        public void Insert(Appointment appointment)
        {
            using (var dbContext = new SoftTehnicaDbContext())
            {
                dbContext.Entry(appointment.Doctor).State = EntityState.Unchanged;
                dbContext.Entry(appointment.Procedure).State = EntityState.Unchanged;
                dbContext.Entry(appointment.Time).State = EntityState.Unchanged;
                dbContext.Appointments.Add(appointment);
                dbContext.SaveChanges();
            }
        }

        public IList<Appointment> GetAll()
        {
            using (var dbContext = new SoftTehnicaDbContext())
            {
                return
                    dbContext.Appointments.Include(x => x.Doctor)
                        .Include(x => x.Time)
                        .Include(x => x.Procedure)
                        .ToList();
            }
        }
    }
}