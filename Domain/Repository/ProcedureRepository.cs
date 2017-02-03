using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repository.Interfaces;

namespace Domain.Repository
{
    public class ProcedureRepository:IProcedureRepository
    {
        public void Insert(Procedure procedure)
        {
            using (var dbContext = new SoftTehnicaDbContext())
            {
                dbContext.Procedures.Add(procedure);
                dbContext.SaveChanges();
            }
        }

        public IList<Procedure> GetAll()
        {
            using (var dbContext = new SoftTehnicaDbContext())
            {
                var d = dbContext.Procedures;
                var e = d.ToList();
                return e;
                //dbContext.Procedures.ToList();
            }
        }

        public Procedure GetById(long id)
        {
            using (var dbContext = new SoftTehnicaDbContext())
            {
                return dbContext.Procedures.SingleOrDefault(x=>x.Id==id);
            }
        }
    }
}