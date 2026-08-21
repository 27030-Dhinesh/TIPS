using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExpenseTracker.Repositories.Utility
{
    /// <summary>
    /// Provides JSON serialization and deserialization support for
    /// <see cref="DateOnly"/> values.
    /// </summary>
    public class JsonDateOnlyConverter : JsonConverter<DateOnly>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonDateOnlyConverter"/> class.
        /// </summary>
        public JsonDateOnlyConverter()
        {
        }

        /// <inheritdoc/>
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? data = reader.GetString();
            if (data is null)
            {
                throw new JsonException("Data value is missing or null.");
            }

            return DateOnly.Parse(data);
        }

        /// <inheritdoc/>
        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
