
using IdeaBox.Data.Models.Types;
using IdeaBox.Mapper.Attributes;

namespace IdeaBox.Archive
{

    [ConditionalMapClass(typeof(Suggestion), nameof(BaseIdeaType.IdeaTypeName), "uitje")]
    [ConditionalMapClass(typeof(Outing), nameof(BaseIdeaType.IdeaTypeName), "suggestie")]
    public class IdeaType
    {
        public IdeaType(string name)
            => TypeName = name;

        public string TypeName { get; set; }


        [MapProperty(nameof(Outing.Begin))]
        public DateTime? Begin { get; set; }

        [MapProperty(nameof(Outing.End))]
        public DateTime? End { get; set; }
    }
}
