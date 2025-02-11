﻿
using IdeaBox.Mapper.Attributes;

namespace IdeaBox.Data.Models
{
    [MapClass(typeof(Archive.User))]
    public class User
    {
        [MapProperty(nameof(Archive.User.UserName))]
        public string? UserName { get; set; }

        [MapProperty(nameof(Archive.User.UserId))]
        public int? UserId { get; set; }
    }
}
