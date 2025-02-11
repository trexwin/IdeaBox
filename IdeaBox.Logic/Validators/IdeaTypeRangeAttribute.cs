using IdeaBox.Data.Helper;

namespace IdeaBox.Logic.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class IdeaTypeRangeAttribute : StringRangeAttribute
    {
        public IdeaTypeRangeAttribute() : base(IdeaTypeHelper.GetIdeaTypes())
        { }
    }
}
