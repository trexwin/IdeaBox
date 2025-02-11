using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
