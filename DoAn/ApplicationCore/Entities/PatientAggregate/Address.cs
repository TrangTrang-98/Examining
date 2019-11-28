
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ApplicationCore;
namespace ApplicationCore.Entities.PatientAggregate
{
    [Owned]
    public class Address : ValueObject// value object -- Patient
    {
        public string NumHouse{get;  set;}
        public string Street{get;  set;}
        public string District{get;  set;}
        public string City{get;  set;}
        public string Country{get;  set;}

        public Address(){}
        public Address(string number, string street, string district, string city, string country)
        {
            NumHouse = number;
            Street = street;
            District = district;
            City = city;
            Country = country;
        }
    }

}
    
