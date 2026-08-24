using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record CheckStatusResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Current API version
    /// </summary>
    [JsonPropertyName("api_version")]
    public required string ApiVersion { get; set; }

    /// <summary>
    /// How to authenticate a request
    /// </summary>
    [JsonPropertyName("authentication")]
    public required string Authentication { get; set; }

    /// <summary>
    /// Developer portal: quickstart, auth, webhooks
    /// </summary>
    [JsonPropertyName("developer_portal_url")]
    public required string DeveloperPortalUrl { get; set; }

    /// <summary>
    /// Human readable API reference
    /// </summary>
    [JsonPropertyName("documentation_url")]
    public required string DocumentationUrl { get; set; }

    /// <summary>
    /// OpenAPI description of this API
    /// </summary>
    [JsonPropertyName("openapi_url")]
    public required string OpenapiUrl { get; set; }

    [JsonPropertyName("rate_limit")]
    public required CheckStatusResponseRateLimit RateLimit { get; set; }

    /// <summary>
    /// 'ok' while the API is serving requests
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; set; }

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
