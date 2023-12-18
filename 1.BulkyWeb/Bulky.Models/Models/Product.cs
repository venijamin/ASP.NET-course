using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models;

public class Product
{
    [Key] public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    [DisplayName("Product Title")]
    public string Title { get; set; }

    [Required] public string ISBN { get; set; }

    [Required] public string Author { get; set; }

    [Required] [DisplayName("List Price")] public double ListPrice { get; set; }
}