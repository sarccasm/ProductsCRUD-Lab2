using System.ComponentModel.DataAnnotations;
namespace ProductsCRUD.Models;
public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Вкажіть назву товару.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Назва має містити від 2 до 100 символів.")]
    [Display(Name = "Назва")]
    public string Name { get; set; } = string.Empty;
    [Range(0.01, 99999999, ErrorMessage = "Ціна має бути більшою за нуль.")]
    [Display(Name = "Ціна (грн)")]
    public decimal Price { get; set; }
    [StringLength(500, ErrorMessage = "Максимум 500 символів.")]
    [Display(Name = "Опис")]
    public string? Description { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Виберіть категорію.")]
    [Display(Name = "Категорія")]
    public int CategoryId { get; set; }
}
