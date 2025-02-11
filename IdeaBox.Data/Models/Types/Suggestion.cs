using IdeaBox.Mapper.Attributes;

namespace IdeaBox.Data.Models.Types
{
    [IdeaType("suggestie")]
    [MapClass(typeof(Archive.IdeaType))]
    public class Suggestion : BaseIdeaType
    { }
}
