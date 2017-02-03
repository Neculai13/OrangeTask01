using System;

namespace Domain.Entities
{
    public class Appointment:Entity
    {
        public Appointment(){}

        public Appointment(string name, string surname, string telNumber, DateTimeOffset date, Procedure procedure,
            Doctor doctor, WorkingHour time)
        {
            Name = name;
            Surname = surname;
            TelNumber = telNumber;
            Date = date;
            Procedure = procedure;
            Doctor = doctor;
            Time = time;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string TelNumber { get; set; }
        public DateTimeOffset Date { get; set; }
        public Procedure Procedure { get; set; }
        public Doctor Doctor { get; set; }
        public WorkingHour Time { get; set; }
    }
}
