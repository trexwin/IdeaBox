using IdeaBox.Mapper.Attributes;
using IdeaBox.Storage;

namespace IdeaBox.Archive
{
    [MapClass(typeof(Data.Models.Idea))]
    public class Idea : IStorageItem
    {
        public Idea(int id, DateTime creationdate)
        {
            Id = id;
            CreationDate = creationdate;
        }

        [MapProperty(nameof(Data.Models.Idea.Id))]
        public int Id { get; set; }

        [MapProperty(nameof(Data.Models.Idea.CreationDate))]
        public DateTime CreationDate { get; set; }

        [MapProperty(nameof(Data.Models.Idea.Subject))]
        public string? Subject { get; set; }

        [MapProperty(nameof(Data.Models.Idea.Body))]
        public string? Body { get; set; }

        [MapProperty(nameof(Data.Models.Idea.User), IsNested = true)]
        public User? User { get; set; }

        [MapProperty(nameof(Data.Models.Idea.IdeaType), IsNested = true)]
        public IdeaType? IdeaType { get; set; }


        [MapProperty(nameof(Data.Models.Idea.Categories))]
        public string[]? Categories { get; set; }
    }
}
