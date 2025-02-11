using IdeaBox.Data.Models.Types;
using IdeaBox.Mapper.Attributes;

namespace IdeaBox.Data.Models
{
    [MapClass(typeof(Archive.Idea))]
    public class Idea
    {
        [MapProperty(nameof(Archive.Idea.Id))]
        public int Id { get; set; }

        [MapProperty(nameof(Archive.Idea.CreationDate))]
        public DateTime CreationDate { get; set; }

        [MapProperty(nameof(Archive.Idea.Subject))]
        public string? Subject { get; set; }

        [MapProperty(nameof(Archive.Idea.Body))]
        public string? Body { get; set; }

        [MapProperty(nameof(Archive.Idea.User), IsNested = true)]
        public User? User { get; set; }

        [MapProperty(nameof(Archive.Idea.IdeaType), IsNested = true)]
        public BaseIdeaType? IdeaType { get; set; }

        [MapProperty(nameof(Archive.Idea.Categories))]
        public string[]? Categories { get; set; }
    }
}