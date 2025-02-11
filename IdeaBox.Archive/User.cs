
namespace IdeaBox.Archive
{
    public class User
    {
        public User (string username, int userid)
        {
            UserName = username;
            UserId = userid;
        }

        public string UserName { get; set; }
        public int UserId { get; set; }
    }
}
