using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSC02.Models
{
    public class BaseEntity
    {
        public string Id { get; set; }

        [Display(Name = "ساخته شده در ")]
        [Required]
        [MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر")]
        public DateTime CreateDate { get; set; }


        [Display(Name ="ویرایش شده در")]
        
        public DateTime? ModifiedDate { get; set; }
        public bool ItemStatus { get; set; }

        [NotMapped()] // برای اینکه در دیتابیس ذخیره نشود
        public string Captcha { get; set; }
        

       
    }
}
