using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestWithASPNET10.JsonSerializers
{
    public class GenderSerializer : JsonConverter<string>
    {
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString() ?? string.Empty;
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            var format = value == "Male" ? "M" : "F";
            writer.WriteStringValue(format);
        }
    }
}
