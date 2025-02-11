using IdeaBox.Data.Helper;

namespace IdeaBox.Backend.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class IdeaTypeRangeAttribute : StringRangeAttribute
    {
        public IdeaTypeRangeAttribute() : base(IdeaTypeHelper.GetIdeaTypes())
        { }
    }
}
