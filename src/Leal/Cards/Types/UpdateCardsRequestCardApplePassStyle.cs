using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[JsonConverter(
    typeof(UpdateCardsRequestCardApplePassStyle.UpdateCardsRequestCardApplePassStyleSerializer)
)]
[Serializable]
public readonly record struct UpdateCardsRequestCardApplePassStyle : IStringEnum
{
    public static readonly UpdateCardsRequestCardApplePassStyle StoreCard = new(Values.StoreCard);

    public static readonly UpdateCardsRequestCardApplePassStyle Poster = new(Values.Poster);

    public UpdateCardsRequestCardApplePassStyle(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static UpdateCardsRequestCardApplePassStyle FromCustom(string value)
    {
        return new UpdateCardsRequestCardApplePassStyle(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(UpdateCardsRequestCardApplePassStyle value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateCardsRequestCardApplePassStyle value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateCardsRequestCardApplePassStyle value) =>
        value.Value;

    public static explicit operator UpdateCardsRequestCardApplePassStyle(string value) =>
        new(value);

    internal class UpdateCardsRequestCardApplePassStyleSerializer
        : JsonConverter<UpdateCardsRequestCardApplePassStyle>
    {
        public override UpdateCardsRequestCardApplePassStyle Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new UpdateCardsRequestCardApplePassStyle(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateCardsRequestCardApplePassStyle value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateCardsRequestCardApplePassStyle ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new UpdateCardsRequestCardApplePassStyle(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateCardsRequestCardApplePassStyle value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string StoreCard = "store_card";

        public const string Poster = "poster";
    }
}
