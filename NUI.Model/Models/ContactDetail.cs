using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NUI.Model.Models
{
    [Table("ContactDetails")]
    public class ContactDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(256)]
        public string Website { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public string Other { get; set; }

        [DefaultValue(0)]
        public double? Lat { get; set; }

        [DefaultValue(0)]
        public double? Lng { get; set; }

        public bool Status { get; set; }
    }
}