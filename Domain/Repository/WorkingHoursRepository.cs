using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repository.Interfaces;

namespace Domain.Repository
{
    public class WorkingHoursRepository:IWorkingHoursRepository
    {
        public void Insert(WorkingHour workingHour)
        {
            using (var dbContext = new SoftTehnicaDbContext())
            {
                dbContext.WorkingHours.Add(workingHour);
                dbContext.SaveChanges();
            }
        }

        public IList<WorkingHour> GetFreeWorkingHours(long doctorId, DateTimeOffset date)
        {
            using (var dbContext = new SoftTehnicaDbContext())
            {
                var timeIds = dbContext.Appointments.Where(x => x.Doctor.Id == doctorId)
                    .Where(x => x.Date == date).Select(x=>x.Time);
                var t =
                    dbContext.WorkingHours.Where(y => y.Doctors.Any(x => x.Id == doctorId))
                        .Where(x => !timeIds.Any(y => y.Id==x.Id))
                        .ToList();
                return t;
            }
        }

        public WorkingHour GetById(long id)
        {
            using (var dbContext = new SoftTehnicaDbContext())
            {
                return dbContext.WorkingHours.SingleOrDefault(x => x.Id == id);
            }
        }
    }
}