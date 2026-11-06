using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[JsonConverter(typeof(CreateCardsRequestCardQrStyle.CreateCardsRequestCardQrStyleSerializer))]
[Serializable]
public readonly record struct CreateCardsRequestCardQrStyle : IStringEnum
{
    public static readonly CreateCardsRequestCardQrStyle Link = new(Values.Link);

    public static readonly CreateCardsRequestCardQrStyle Code = new(Values.Code);

    public CreateCardsRequestCardQrStyle(string value)
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
    public static CreateCardsRequestCardQrStyle FromCustom(string value)
    {
        return new CreateCardsRequestCardQrStyle(value);
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

    public static bool operator ==(CreateCardsRequestCardQrStyle value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateCardsRequestCardQrStyle value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateCardsRequestCardQrStyle value) => value.Value;

    public static explicit operator CreateCardsRequestCardQrStyle(string value) => new(value);

    internal class CreateCardsRequestCardQrStyleSerializer
        : JsonConverter<CreateCardsRequestCardQrStyle>
    {
        public override CreateCardsRequestCardQrStyle Read(
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
            return new CreateCardsRequestCardQrStyle(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateCardsRequestCardQrStyle value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateCardsRequestCardQrStyle ReadAsPropertyName(
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
            return new CreateCardsRequestCardQrStyle(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateCardsRequestCardQrStyle value,
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
        public const string Link = "link";

        public const string Code = "code";
    }
}
