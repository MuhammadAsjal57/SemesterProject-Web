using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models
{
    public class employe
    {
        [Display(Name = "Emp ID")]
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int empID { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "Please enter FirstName")]
        [Display(Name = "Name")]
        public string empName { get; set; }

        [Required(ErrorMessage = "Please enter FirstName")]
        [Display(Name = "DOB")]
        public DateTime date { get; set; }

     
        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please Select the gender")]
        public string Gender { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter FirstName")]
        [Display(Name = "Date Of Joining")]
        public DateTime datejoin { get;set; }
        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please Select the gender")]
        public string dept { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Designation Name")]
        [Required(ErrorMessage = "Please Select the gender")]
        public string designationn { get; set; }

    }
}
