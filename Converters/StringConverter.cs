using System.Text.Json;
using System.Text.Json.Serialization;

namespace GameStore.Frontend.Converters;
// we made this folder converted for the reason that in GameSummary we receive the genreId as a string, but in the api is returened as a number
public class StringConverter : JsonConverter<string?>
{
	public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.Number)
		{
			return reader.GetInt32().ToString();
		}
		return reader.GetString();
	}
	public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value);
	}
}
