using IdeaBox.Data.JsonConverter;
using IdeaBox.Data.Models.Types;
using IdeaBox.Storage;
using System.Text.Json.Serialization;

namespace IdeaBox.Data.Models
{
    public class Idea : IStorageItem
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public User? User { get; set; }

        [JsonConverter(typeof(IdeaTypeConverter))]
        public BaseIdeaType? IdeaType { get; set; }
        public string[]? Categories { get; set; }

        public void Sanitise()
        {
            if (User != null && User.UserId == null && User.UserName == null)
                User = null;
        }
    }
}