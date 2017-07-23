using NUI.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NUI.Model.Models
{
    [Table("ProductCategories")]
    public class ProductCategory : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(255)]
        [Required]
        public string Alias { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public int? ParentID { get; set; }
        public int? DisplayOrder { get; set; }

        [MaxLength(255)]
        public string Images { get; set; }

        public bool? HomeFlag { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
    }
}