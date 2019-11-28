using System;
using System.Collections.Generic;
using ApplicationCore.Interfaces;
using ApplicationCore;
namespace ApplicationCore.Entities.PatientAggregate
{
    public class Patient : IAggregateRoot
    {
        public string PatientId { get;  set; }

        public string PatientName { get;  set; }

        public Gender Gender { get;  set; }

        public System.DateTime Birthday { get;  set; }

        public ApplicationCore.Entities.PatientAggregate.Address Address { get;  set; }

        public string Phone { get; set; }

        // private List<ApplicationCore.Entities.PatientAggregate.PayForm> _payForm = new List<ApplicationCore.Entities.PatientAggregate.PayForm>();
        // IEnumerable<ApplicationCore.Entities.PatientAggregate.PayForm> payForms => _payForm.AsReadOnly();

        

       // public ICollection<Enrollment> Enrollment{get; set;}

        public Patient(){}
        public Patient(string id, string name, Gender gender, DateTime birth, string phone)
        {
            this.PatientId = id;
            this.PatientName = name;
            this.Gender = gender;
            this.Birthday = birth;
            this.Phone = phone;
        }

    }

}