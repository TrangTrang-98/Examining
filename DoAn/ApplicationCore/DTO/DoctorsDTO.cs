using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore;
namespace ApplicationCore.DTO
{
    public class DoctorsDTO
    {
       //[Required]
       [Display(Name = "Doctor Id")]
        public string DoctorId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]        
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }

        public Gender Gender{get; set;}
        
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Số điện thoại không đúng cú pháp")]
        [Required]
        public string Phone { get; set; }
    }
}