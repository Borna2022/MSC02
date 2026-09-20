using System.ComponentModel.DataAnnotations;

namespace MSC02.Models
{
    public class Heat:BaseEntity
    {

        [Required]
        [Display(Name="نام کاربری")]
        [MaxLength(50,ErrorMessage ="حداکثر تعداد مجاز 50")]
        [MinLength(50, ErrorMessage = "حداکثر تعداد مجاز 6")]

        public string DailyNumber { get; set; }
        public string HeatNumber { get; set; }

        public string? Note { get; set; }
        public string Grade { get; set; }

    }
}
