using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record CheckStatusResponseVersioning : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The version to build against
    /// </summary>
    [JsonPropertyName("current")]
    public required string Current { get; set; }

    /// <summary>
    /// Versions that are deprecated but still serving
    /// </summary>
    [JsonPropertyName("deprecated")]
    public IEnumerable<string> Deprecated { get; set; } = new List<string>();

    /// <summary>
    /// The published versioning and deprecation policy
    /// </summary>
    [JsonPropertyName("policy_url")]
    public required string PolicyUrl { get; set; }

    /// <summary>
    /// The headers a deprecated version sends
    /// </summary>
    [JsonPropertyName("signalling")]
    public required string Signalling { get; set; }

    /// <summary>
    /// Every version still serving requests
    /// </summary>
    [JsonPropertyName("supported")]
    public IEnumerable<string> Supported { get; set; } = new List<string>();

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
