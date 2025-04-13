using System.ComponentModel.DataAnnotations;
using DogusProject.Models.Repositories;

namespace DogusProject.Models.Validations;

public class UniqueCategoryAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var categoryRepository = validationContext.GetService(typeof(ICategoryRepository)) as ICategoryRepository;
        if (categoryRepository == null)
            return ValidationResult.Success;

        var categoryName = value?.ToString();
        if (string.IsNullOrEmpty(categoryName))
            return ValidationResult.Success;

        var existingCategory = categoryRepository.GetAllCategories()
            .FirstOrDefault(c => c.Name == categoryName);

        return existingCategory != null
            ? new ValidationResult("Girdiğiniz kategori zaten var.")
            : ValidationResult.Success;
    }
}