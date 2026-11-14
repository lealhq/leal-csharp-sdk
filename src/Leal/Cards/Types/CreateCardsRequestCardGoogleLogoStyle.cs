using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[JsonConverter(
    typeof(CreateCardsRequestCardGoogleLogoStyle.CreateCardsRequestCardGoogleLogoStyleSerializer)
)]
[Serializable]
public readonly record struct CreateCardsRequestCardGoogleLogoStyle : IStringEnum
{
    public static readonly CreateCardsRequestCardGoogleLogoStyle Round = new(Values.Round);

    public static readonly CreateCardsRequestCardGoogleLogoStyle Wide = new(Values.Wide);

    public CreateCardsRequestCardGoogleLogoStyle(string value)
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
    public static CreateCardsRequestCardGoogleLogoStyle FromCustom(string value)
    {
        return new CreateCardsRequestCardGoogleLogoStyle(value);
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

    public static bool operator ==(CreateCardsRequestCardGoogleLogoStyle value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateCardsRequestCardGoogleLogoStyle value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateCardsRequestCardGoogleLogoStyle value) =>
        value.Value;

    public static explicit operator CreateCardsRequestCardGoogleLogoStyle(string value) =>
        new(value);

    internal class CreateCardsRequestCardGoogleLogoStyleSerializer
        : JsonConverter<CreateCardsRequestCardGoogleLogoStyle>
    {
        public override CreateCardsRequestCardGoogleLogoStyle Read(
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
            return new CreateCardsRequestCardGoogleLogoStyle(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateCardsRequestCardGoogleLogoStyle value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateCardsRequestCardGoogleLogoStyle ReadAsPropertyName(
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
            return new CreateCardsRequestCardGoogleLogoStyle(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateCardsRequestCardGoogleLogoStyle value,
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
        public const string Round = "round";

        public const string Wide = "wide";
    }
}
