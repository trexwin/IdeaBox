using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaBox.Mapper.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ConditionalMapClassAttribute : Attribute
    {
        public Type Type { get; }
        public string PropertyName { get; }
        public object? ConditionalValue { get; }

        public ConditionalMapClassAttribute(Type type, string propertyname, object? conditionalvalue)
        {
            Type = type;
            PropertyName = propertyname;
            ConditionalValue = conditionalvalue;
        }
    }
}
