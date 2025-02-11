
using IdeaBox.Data.Models.Types;
using System.Reflection;

namespace IdeaBox.Data.Helper
{
    public static class IdeaTypeHelper
    {
        public static Type? GetIdeaTypeType(string? ideaTypeName)
        {
            if (string.IsNullOrEmpty(ideaTypeName))
                return null;

            var types = typeof(BaseIdeaType).Assembly.GetTypes();
            return types?.SingleOrDefault(t => t.GetCustomAttribute<IdeaTypeAttribute>()?.TypeName == ideaTypeName);
        }

        public static BaseIdeaType? CreateIdeaType(string? ideaTypeName)
        {
            var ideaType = GetIdeaTypeType(ideaTypeName);
            return ideaType?.GetConstructor([])?.Invoke([]) as BaseIdeaType;
        }

        public static string[] GetIdeaTypes()
        {
            var types = typeof(BaseIdeaType).Assembly.GetTypes()?.Select(t => t.GetCustomAttribute<IdeaTypeAttribute>());
            return types?.Where(a => a is not null).Select(a => a?.TypeName ?? "").ToArray() ?? [];
        }
    }
}
