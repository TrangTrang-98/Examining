using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Entities.PatientAggregate;
using ApplicationCore;
namespace ApplicationCore.DTO
{
    public class PatientsDTO
    {
        //enum Gender { Nam = "Nam", Nu = "Nữ"}
        [Display(Name = "Patient Id")]
        public string PatientId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        public Gender Gender{get; set;}

        [DataType(DataType.Date)]
       // [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        // [Required]
        // [StringLength(30)]
        // [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        // public Address Address { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        public string Phone { get; set; }
    }
}