using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record CheckStatusResponseRateLimit : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Requests allowed per window
    /// </summary>
    [JsonPropertyName("limit")]
    public required int Limit { get; set; }

    /// <summary>
    /// What the limit is counted against
    /// </summary>
    [JsonPropertyName("scope")]
    public required string Scope { get; set; }

    /// <summary>
    /// Length of the window in seconds
    /// </summary>
    [JsonPropertyName("window_seconds")]
    public required int WindowSeconds { get; set; }

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
