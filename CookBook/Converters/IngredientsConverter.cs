using CookBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CookBook.Converters;
public class IngredientsConverter : JsonConverter<List<Ingredient>>
{
    public override List<Ingredient>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var ingredients = new List<Ingredient>();

        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException("Expected StartArray token.");
        }

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
                break;

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                reader.Read();
                var name = reader.GetString();

                reader.Read();
                var amount = reader.GetString();

                ingredients.Add(new Ingredient { Name = name, Amount = amount });

                reader.Read(); 
            }
        }

        return ingredients;
    }

    public override void Write(Utf8JsonWriter writer, List<Ingredient> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        foreach (var ingredient in value)
        {
            writer.WriteStartArray();
            writer.WriteStringValue(ingredient.Name);
            writer.WriteStringValue(ingredient.Amount);
            writer.WriteEndArray();
        }
        writer.WriteEndArray();
    }
}

