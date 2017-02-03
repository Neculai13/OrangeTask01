using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repository.Interfaces
{
    public interface IAppointmentRepository
    {
        void Insert(Appointment appointment);
        IList<Appointment> GetAll();
    }
}