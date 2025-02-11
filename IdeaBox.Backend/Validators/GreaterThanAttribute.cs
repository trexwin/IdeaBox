using System.ComponentModel.DataAnnotations;

namespace IdeaBox.Backend.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class GreaterThanAttribute : ValidationAttribute
    {
        public string PropertyName { get; }

        public GreaterThanAttribute(string propertyName)
            => PropertyName = propertyName;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var obj = validationContext.ObjectInstance;
            var property = obj.GetType().GetProperty(PropertyName)
                ?? throw new InvalidOperationException($"No property found in {obj.GetType().Name} named {PropertyName}.");

            
            var otherVal = property.GetValue(obj);
            if (otherVal == null)
                return ValidationResult.Success;

            if(value is IComparable comp && otherVal is IComparable otherComp)
            {
                // value > otherVal
                if (comp.CompareTo(otherComp) > 0)
                    return ValidationResult.Success;
                return new ValidationResult($"The {validationContext.DisplayName} field must be greater than that of {PropertyName}.");
            }
            throw new InvalidOperationException($"{property.PropertyType.Name} does not implement {nameof(IComparable)}.");
        }
    }
}
