
using System.Reflection;

namespace IdeaBox.Mapper.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MapPropertyAttribute : Attribute
    {
        public string Name { get; }
        public bool IsNested { get; init; }

        public MapPropertyAttribute(string name)
            => Name = name;
    }
}
