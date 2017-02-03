using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repository.Interfaces;

namespace Domain.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        public void Insert(Doctor doctor)
        {
            using (var dbContext = new SoftTehnicaDbContext())
            {
                dbContext.Doctors.Add(doctor);
                dbContext.SaveChanges();
            }
        }

        public IList<Doctor> GetDoctors(Procedure procedure)
        {
            using (var dbContext = new SoftTehnicaDbContext())
            {
                return dbContext.Doctors.Where(x => x.Procedures.Any(y=>y.Id == procedure.Id)).ToList();
            }
        }

        public Doctor GetById(long id)
        {
            using (var dbContext = new SoftTehnicaDbContext())
            {
                return dbContext.Doctors.SingleOrDefault(x => x.Id == id);
            }
        }
    }
}