using System.ComponentModel.DataAnnotations;

namespace IdeaBox.Logic.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RequiredIfSetAttribute : ValidationAttribute
    {
        public string PropertyName { get; }

        public RequiredIfSetAttribute(string propertyName)
            => PropertyName = propertyName;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var obj = validationContext.ObjectInstance;
            var property = obj.GetType().GetProperty(PropertyName)
                ?? throw new InvalidOperationException($"No property found in {obj.GetType().Name} named {PropertyName}.");

            if (property.GetValue(obj) != null && value == null)
                return new ValidationResult($"The {validationContext.DisplayName} field is required if {PropertyName} is set.");
            return ValidationResult.Success;
        }

    }
}
