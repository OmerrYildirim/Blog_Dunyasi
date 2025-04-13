using System.ComponentModel.DataAnnotations;
using DogusProject.Models.Repositories;

namespace DogusProject.Models.Validations;

public class UniqueUserNameAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var dbContext = validationContext.GetService(typeof(AppDbContext)) as AppDbContext;
        if (dbContext == null)
            return ValidationResult.Success;

        var userName = value?.ToString();
        if (string.IsNullOrEmpty(userName))
            return ValidationResult.Success;

        var userNameExists = dbContext.Users.Any(u => u.UserName == userName);

        return userNameExists
            ? new ValidationResult("Bu kullanıcı adı zaten kayıtlı.")
            : ValidationResult.Success;
    }
}