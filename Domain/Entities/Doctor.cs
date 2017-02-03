using System.Collections.Generic;

namespace Domain.Entities
{
    public class Doctor:Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public IList<Procedure> Procedures { get; set; }
        public IList<WorkingHour> WorkingHours { get; set; }
    }
}
