
using IdeaBox.Data.Models.Types;
using IdeaBox.Mapper.Attributes;

namespace IdeaBox.Data.Archive
{

    [ConditionalMapClass(typeof(Suggestion), nameof(TypeName), "suggestie")] // Need smarter solution for name binding, for now good enough
    [ConditionalMapClass(typeof(Outing), nameof(TypeName), "uitje")] // Probably something with using enums or such
    public class IdeaType
    {
        public string? TypeName { get; set; }

        [MapProperty(nameof(Outing.Begin))]
        public DateTime? Begin { get; set; }

        [MapProperty(nameof(Outing.End))]
        public DateTime? End { get; set; }
    }
}
