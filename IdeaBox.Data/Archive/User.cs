
using IdeaBox.Mapper.Attributes;

namespace IdeaBox.Data.Archive
{
    [MapClass(typeof(Models.User))]
    public class User
    {
        [MapProperty(nameof(Models.User.UserName))]
        public string? UserName { get; set; }

        [MapProperty(nameof(Models.User.UserId))]
        public int? UserId { get; set; }
    }
}
