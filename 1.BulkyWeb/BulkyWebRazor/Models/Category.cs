using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWebRazor.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    [DisplayName("Category Name")]
    public string Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1,Int32.MaxValue)]
    public int DisplayOrder { get; set; }
}