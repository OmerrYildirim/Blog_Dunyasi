using System.ComponentModel.DataAnnotations;

namespace DogusProject.Models.Validations;

public class CustomCategoryRequiredAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var instance = validationContext.ObjectInstance;
        var isCustomCategoryProperty = instance.GetType().GetProperty("IsCustomCategory");
        var customCategoryNameProperty = instance.GetType().GetProperty("CustomCategoryName");

        if (isCustomCategoryProperty == null || customCategoryNameProperty == null)
            return ValidationResult.Success;

        var isCustomCategory = (bool)isCustomCategoryProperty.GetValue(instance)!;
        var customCategoryName = customCategoryNameProperty.GetValue(instance) as string;

        if (isCustomCategory && string.IsNullOrEmpty(customCategoryName))
        {
            return new ValidationResult("Yeni kategori adı boş bırakılamaz.");
        }

        return ValidationResult.Success;
    }
}