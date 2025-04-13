using System.ComponentModel.DataAnnotations;
using DogusProject.Models.Repositories;

namespace DogusProject.Models.Validations;

public class UniqueEmailAttribute() : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var dbContext = validationContext.GetService(typeof(AppDbContext)) as AppDbContext;
        if (dbContext == null)
            return ValidationResult.Success;

        var email = value?.ToString();
        if (string.IsNullOrEmpty(email))
            return ValidationResult.Success;

        var emailExists = dbContext.Users.Any(u => u.Email == email);
        
        return emailExists 
            ? new ValidationResult("Bu email adresi zaten kayıtlı.")
            : ValidationResult.Success;
    }
}