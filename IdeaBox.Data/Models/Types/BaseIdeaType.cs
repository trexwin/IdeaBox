using IdeaBox.Data.Extensions;
using IdeaBox.Mapper.Attributes;

namespace IdeaBox.Data.Models.Types
{
    public abstract class BaseIdeaType
    {
        [MapProperty(nameof(Archive.IdeaType.TypeName))]
        public string IdeaTypeName 
            => this.GetIdeaTypeAttributeName() 
                ?? throw new InvalidOperationException("BaseIdeaType is not annotated with IdeaTypeAttribute.");
    }
}
