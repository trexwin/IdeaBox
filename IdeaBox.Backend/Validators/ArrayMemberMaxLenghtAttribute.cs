using System.ComponentModel.DataAnnotations;

namespace IdeaBox.Backend.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ArrayMemberMaxLenghtAttribute : ValidationAttribute
    {
        public int MaxLength { get; }

        public ArrayMemberMaxLenghtAttribute(int maxLength)
        {
            MaxLength = maxLength;
            ErrorMessage = $"Members of this field may not exceed {maxLength} characters.";
        }

        public override bool IsValid(object? value) 
            => (value as string[])?.All(s => s.Length <= MaxLength) ?? true;
    }
}
