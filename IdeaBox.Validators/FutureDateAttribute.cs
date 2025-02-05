using System.ComponentModel.DataAnnotations;

namespace IdeaBox.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FutureDateAttribute : ValidationAttribute
    {
        public FutureDateAttribute()
            => ErrorMessage = $"This field must contain a future date.";

        public override bool IsValid(object? value)
        {
            if (value == null) 
                return true;
            if (value is DateTime time)
                return time > DateTime.Now;
            return false;
        }
    }

}
