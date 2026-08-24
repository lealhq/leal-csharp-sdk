using global::System.Text.Json.Serialization;
using Leal.Core;
using OneOf;

namespace Leal;

/// <summary>
/// A JSON error payload. Agents should read `error` for a human readable summary and `errors` for per field validation messages when present.
/// </summary>
[Serializable]
public record Error : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Human readable description of what went wrong.
    /// </summary>
    [JsonPropertyName("error")]
    public string? Error_ { get; set; }

    /// <summary>
    /// Validation messages, either a list of strings or an object keyed by field name.
    /// </summary>
    [JsonPropertyName("errors")]
    public OneOf<IEnumerable<string>, Dictionary<string, IEnumerable<string>>>? Errors { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
