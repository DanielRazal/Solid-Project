using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Product : BaseEntity
    {
        [StringLength(300)]
        public string Description { get; set; } = string.Empty;
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Photo")]
        public string PhotoUrl { get; set; } = string.Empty;

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; } = null!;
    }
}
