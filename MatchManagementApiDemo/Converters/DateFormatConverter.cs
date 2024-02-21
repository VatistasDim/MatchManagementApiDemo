using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MatchManagementApiDemo.Converters
{
    /// <summary>
    /// Custom JSON converter for serializing and deserializing DateTime properties with a specific date format.
    /// </summary>
    public class DateFormatConverter : JsonConverter<DateTime>
    {
        /// <summary>
        /// Reads the JSON representation of a DateTime and converts it to a DateTime object.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">The serializer options.</param>
        /// <returns>The deserialized DateTime object.</returns>
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (DateTime.TryParse(reader.GetString(), out DateTime result))
            {
                return result;
            }
            return DateTime.MinValue;
        }

        /// <summary>
        /// Writes the DateTime object to its JSON representation with a specific date format.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The DateTime value to write.</param>
        /// <param name="options">The serializer options.</param>
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
        }
    }
}
