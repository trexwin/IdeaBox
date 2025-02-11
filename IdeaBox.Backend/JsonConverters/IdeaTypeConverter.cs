/*
using System.Text.Json.Serialization;
using System.Text.Json;
using IdeaBox.Backend.Storage.Models;
using IdeaBox.Data.Models.Types;
using IdeaBox.Data.Helper;

namespace IdeaBox.Backend.JsonConverters
{
    public class IdeaTypeConverter : JsonConverter<IdeaType>
    {
        public override IdeaType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Utf8JsonReader tmpReader = reader;

            tmpReader.Read(); // Read object open
            while (tmpReader.GetString() != nameof(BaseIdeaType.IdeaTypeName))
            {
                tmpReader.Read(); // Read label
                tmpReader.Read(); // Read value
                if(tmpReader.TokenType != JsonTokenType.PropertyName)
                    throw new InvalidOperationException($"Json file with IdeaType contains no IdeaTypeName.");
            }

            tmpReader.Read(); // Read label
            var ideaTypeName = tmpReader.GetString();
            var type = IdeaTypeHelper.GetIdeaTypeType(ideaTypeName)
                    ?? throw new NotSupportedException($"The IdeaType \"{ideaTypeName}\" i snot supported.");

            return JsonSerializer.Deserialize(ref reader, type, options) as BaseIdeaType;
        }

        public override void Write(Utf8JsonWriter writer, BaseIdeaType value, JsonSerializerOptions options)
            => JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
*/