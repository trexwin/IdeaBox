namespace IdeaBox.Data.Models.Types
{
    [IdeaType("uitje")]
    public class Outing : BaseIdeaType
    {
        public DateTime? Begin { get; set; }
        public DateTime? End { get; set; }
    }
}
