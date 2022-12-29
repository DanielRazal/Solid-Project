using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; } = string.Empty;
    }
}
