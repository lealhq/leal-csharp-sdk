using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[JsonConverter(typeof(UpdateCardsRequestCardQrStyle.UpdateCardsRequestCardQrStyleSerializer))]
[Serializable]
public readonly record struct UpdateCardsRequestCardQrStyle : IStringEnum
{
    public static readonly UpdateCardsRequestCardQrStyle Link = new(Values.Link);

    public static readonly UpdateCardsRequestCardQrStyle Code = new(Values.Code);

    public UpdateCardsRequestCardQrStyle(string value)
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
    public static UpdateCardsRequestCardQrStyle FromCustom(string value)
    {
        return new UpdateCardsRequestCardQrStyle(value);
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

    public static bool operator ==(UpdateCardsRequestCardQrStyle value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateCardsRequestCardQrStyle value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateCardsRequestCardQrStyle value) => value.Value;

    public static explicit operator UpdateCardsRequestCardQrStyle(string value) => new(value);

    internal class UpdateCardsRequestCardQrStyleSerializer
        : JsonConverter<UpdateCardsRequestCardQrStyle>
    {
        public override UpdateCardsRequestCardQrStyle Read(
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
            return new UpdateCardsRequestCardQrStyle(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateCardsRequestCardQrStyle value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateCardsRequestCardQrStyle ReadAsPropertyName(
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
            return new UpdateCardsRequestCardQrStyle(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateCardsRequestCardQrStyle value,
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
