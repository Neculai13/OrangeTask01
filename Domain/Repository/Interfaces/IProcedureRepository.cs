using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repository.Interfaces
{
    public interface IProcedureRepository
    {
        void Insert(Procedure procedure);
        IList<Procedure> GetAll();
        Procedure GetById(long id);
    }
}