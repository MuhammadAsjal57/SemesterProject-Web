using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication6.Models
{
    public class drug
    {
        [Display(Name = "Drug ID")]
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int drugID { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "Please enter FirstName")]
        [Display(Name = "Short Name")]
        public string shortName { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "Please enter FirstName")]
        [Display(Name = "Long Name")]
        public string longName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Please enter FirstName")]
        [Display(Name = "General Discription")]
        public string disc { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Required(ErrorMessage = "Please enter FirstName")]
        [Display(Name = "Chemical Analysis")]
        public string analyse { get; set; }

    }
}
