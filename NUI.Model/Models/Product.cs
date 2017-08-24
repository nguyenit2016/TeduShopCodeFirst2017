using NUI.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NUI.Model.Models
{
    [Table("Products")]
    public class Product : Auditable
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

        public int CategoryID { get; set; }

        [MaxLength(255)]
        public string Images { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int Warranty { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }
        public string Tags { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }

        public virtual IEnumerable<ProductTag> ProductTags { get; set; }
    }
}