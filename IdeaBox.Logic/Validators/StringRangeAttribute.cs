using System.ComponentModel.DataAnnotations;

namespace IdeaBox.Logic.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class StringRangeAttribute : ValidationAttribute
    {
        public string[] Values { get; }

        public StringRangeAttribute(string[] values)
        {
            Values = values;
            var valuesString = string.Join(", ", values ?? []);
            ErrorMessage = $"This field may only have the following values: {valuesString}";
        }

        public override bool IsValid(object? value)
            => Values.Contains(value);
    }
}
