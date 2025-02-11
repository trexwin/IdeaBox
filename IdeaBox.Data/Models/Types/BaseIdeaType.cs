using IdeaBox.Data.Extensions;

namespace IdeaBox.Data.Models.Types
{
    public abstract class BaseIdeaType
    {
        public string IdeaTypeName 
            => this.GetIdeaTypeAttributeName() 
                ?? throw new InvalidOperationException("BaseIdeaType is not annotated with IdeaTypeAttribute.");
    }
}
