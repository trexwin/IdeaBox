using System.ComponentModel.DataAnnotations;

namespace IdeaBox.Backend.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RequiredIfValueAttribute : ValidationAttribute
    {
        public string PropertyName { get; }
        public object Value { get; }

        public RequiredIfValueAttribute(string propertyName, object value)
        {
            PropertyName = propertyName;
            Value = value;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var obj = validationContext.ObjectInstance;
            var property = obj.GetType().GetProperty(PropertyName)
                ?? throw new InvalidOperationException($"No property found in {obj.GetType().Name} named {PropertyName}.");

            var otherVal = property.GetValue(obj);
            if (Value.Equals(otherVal) && value == null)
                return new ValidationResult($"The {validationContext.DisplayName} field must be set if {PropertyName} is set to \"{Value.ToString()}\".");
            return ValidationResult.Success;
        }
    }
}
