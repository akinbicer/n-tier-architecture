using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation;

public static class ValidationTool
{
    public static void Validate(IValidator validator, object entity)
    {
        ValidationContext<object> context = new(entity);
        var result = validator.Validate(context);

        if (result.Errors.Count > 0) throw new ValidationException(result.Errors);
    }
}