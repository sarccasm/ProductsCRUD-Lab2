using System.ComponentModel.DataAnnotations;
namespace ProductsCRUD.Models;
public class Category
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Вкажіть назву категорії.")]
    public string Name { get; set; } = string.Empty;
}
