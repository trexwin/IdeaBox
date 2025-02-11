﻿using IdeaBox.Mapper.Attributes;
using IdeaBox.Storage;

namespace IdeaBox.Data.Archive
{
    [MapClass(typeof(Models.Idea))]
    public class Idea : IStorageItem
    {
        [MapProperty(nameof(Models.Idea.Id))]
        public int Id { get; set; }

        [MapProperty(nameof(Models.Idea.CreationDate))]
        public DateTime CreationDate { get; set; }

        [MapProperty(nameof(Models.Idea.Subject))]
        public string? Subject { get; set; }

        [MapProperty(nameof(Models.Idea.Body))]
        public string? Body { get; set; }

        [MapProperty(nameof(Models.Idea.User), IsNested = true)]
        public User? User { get; set; }

        [MapProperty(nameof(Models.Idea.IdeaType), IsNested = true)]
        public IdeaType? IdeaType { get; set; }

        [MapProperty(nameof(Models.Idea.Categories))]
        public string[]? Categories { get; set; }
    }
}
