using RestWithASPNET10.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET10.Model
{
    [Table("books")]

    public class Book : BaseEntity
    {
        [Required]
        [Column("title", TypeName = "varchar(200)")]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [Column("author", TypeName = "varchar(250)")]
        [MaxLength(250)]
        public string Author { get; set; }
        [Required]
        [Column("price", TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        [Required]
        [Column("launch_date")]
        public DateTime LaunchDate { get; set; }
    }
}
