using System.Collections.Generic;

namespace Domain.Entities
{
    public class Procedure:Entity
    {
        public string Name { get; set; }
        public IList<Doctor> Doctors { get; set; }
    }
}
