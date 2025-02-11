using IdeaBox.Data.Models.Types;
using System.Reflection;

namespace IdeaBox.Data.Extensions
{
    public static class IdeaTypeExtensions
    {
        public static string? GetIdeaTypeAttributeName(this Type type)
            => type.GetCustomAttribute<IdeaTypeAttribute>()?.TypeName;
        public static string? GetIdeaTypeAttributeName(this BaseIdeaType ideaType)
            => ideaType.GetType().GetIdeaTypeAttributeName();
    }
}
