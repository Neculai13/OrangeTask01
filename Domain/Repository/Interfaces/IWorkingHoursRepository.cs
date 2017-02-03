using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repository.Interfaces
{
    public interface IWorkingHoursRepository
    {
        void Insert(WorkingHour workingHour);
        IList<WorkingHour> GetFreeWorkingHours(long doctorId, DateTimeOffset date);
        WorkingHour GetById(long id);
    }
}