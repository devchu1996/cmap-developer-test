using System.ComponentModel.DataAnnotations;

namespace Timesheets.Models
{
    public class TimesheetEntry
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Work Date")]
        [Required]
        public string Date { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]*$")] 
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]*$")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z\s]*$")]
        public string Project { get; set; }

        [Display(Name = "Work Hours")]
        [Required]
        public string Hours { get; set; }
    }
}
