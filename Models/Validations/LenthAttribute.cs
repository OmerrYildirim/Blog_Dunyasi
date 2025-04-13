namespace DogusProject.Models.Validations;

using System.ComponentModel.DataAnnotations;

public class LengthAttribute : ValidationAttribute
{
    public int Min { get; }
    public int Max { get; }

    public LengthAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var stringValue = value as string;

        if (string.IsNullOrEmpty(stringValue))
            return ValidationResult.Success;

        if (stringValue.Length < Min || stringValue.Length > Max)
        {
            return new ValidationResult(ErrorMessage ?? $"The length must be between {Min} and {Max} characters.");
        }

        return ValidationResult.Success;
    }
}