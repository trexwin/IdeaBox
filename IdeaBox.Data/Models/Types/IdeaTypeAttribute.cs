
namespace IdeaBox.Data.Models.Types
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class IdeaTypeAttribute : Attribute
    {
        public string TypeName { get; }
        public IdeaTypeAttribute(string typeName)
            => TypeName = typeName;
    }
}
