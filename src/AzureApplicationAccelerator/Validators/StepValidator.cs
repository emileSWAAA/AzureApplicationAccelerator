using AzureApplicationAccelerator.Services;
using System.ComponentModel.DataAnnotations;

namespace AzureApplicationAccelerator.Validators
{
    public class StepValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var title = value as string;
            if (title.Length > 0 && string.IsNullOrWhiteSpace(title))
            {
                return new ValidationResult("Title cannot be empty.");
            }

            var definitionService = (UIDefinitionService)validationContext.GetService(typeof(UIDefinitionService))!;

            if (definitionService.Definition.Parameters.Steps.Any(s => s.Name.Equals(title.Trim(),StringComparison.OrdinalIgnoreCase)))
            {
                return new ValidationResult($"A step called “{title}” already exists.");
            }

            return ValidationResult.Success!;
        }
    }
}
