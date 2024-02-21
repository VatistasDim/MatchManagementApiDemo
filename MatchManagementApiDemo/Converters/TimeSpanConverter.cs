using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatchManagementApiDemo.Converters
{
    /// <summary>
    /// Custom JSON converter for serializing and deserializing TimeSpan properties.
    /// </summary>
    public class TimeSpanConverter : JsonConverter<TimeSpan>
    {
        /// <summary>
        /// Reads the JSON representation of a TimeSpan and converts it to a TimeSpan object.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">The serializer options.</param>
        /// <returns>The deserialized TimeSpan object.</returns>
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString();
                return TimeSpan.ParseExact(stringValue, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
            }

            return TimeSpan.Zero;
        }

        /// <summary>
        /// Writes the TimeSpan object to its JSON representation.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The TimeSpan value to write.</param>
        /// <param name="options">The serializer options.</param>
        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("hh\\:mm\\:ss"));
        }
    }
}
