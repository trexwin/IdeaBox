
namespace IdeaBox.Mapper.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class MapClassAttribute : Attribute
    {
        public Type Type { get; }

        public MapClassAttribute(Type type)
            => Type = type;
    }
}
