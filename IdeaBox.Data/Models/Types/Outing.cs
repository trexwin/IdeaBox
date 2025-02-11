using IdeaBox.Mapper.Attributes;

namespace IdeaBox.Data.Models.Types
{
    [IdeaType("uitje")]
    [MapClass(typeof(Archive.IdeaType))]
    public class Outing : BaseIdeaType
    {
        [MapProperty(nameof(Archive.IdeaType.Begin))]
        public DateTime? Begin { get; set; }

        [MapProperty(nameof(Archive.IdeaType.End))]
        public DateTime? End { get; set; }
    }
}
