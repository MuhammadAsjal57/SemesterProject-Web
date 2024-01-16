using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models
{
    public class usagecs
    {
        [Display(Name = "Drug Condition ID")]
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int drugcondID { get; set; }
        

        
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Please enter FirstName")]
        [Display(Name = " Discription")]
        public string disc { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "Please enter FirstName")]
        [Display(Name = "Other Details")]
        public string otherdetails { get; set; }


    }
}
