using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repository.Interfaces
{
    public interface IDoctorRepository
    {
        void Insert(Doctor doctor);
        IList<Doctor> GetDoctors(Procedure procedure);
        Doctor GetById(long id);
    }
}