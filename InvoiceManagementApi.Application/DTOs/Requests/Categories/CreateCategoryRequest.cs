using System.ComponentModel.DataAnnotations;

namespace InvoiceManagementApi.Application.DTOs.Requests.Categories;

public class CreateCategoryRequest
{
    [Required]
    [StringLength(80)]
    public string Name { get; set; } = string.Empty;

    [StringLength(255)]
    public string? Description { get; set; }
}

