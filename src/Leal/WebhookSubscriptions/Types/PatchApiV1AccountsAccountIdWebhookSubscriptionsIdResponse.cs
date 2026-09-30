using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record PatchApiV1AccountsAccountIdWebhookSubscriptionsIdResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Parent store ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public required int AccountId { get; set; }

    /// <summary>
    /// ISO 8601 creation timestamp
    /// </summary>
    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    /// <summary>
    /// Your own label for the subscription
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// ISO 8601 time the subscription was disabled
    /// </summary>
    [JsonPropertyName("disabled_at")]
    public required string DisabledAt { get; set; }

    /// <summary>
    /// `disabled_by_user`, `failing` or `blocked_address`
    /// </summary>
    [JsonPropertyName("disabled_reason")]
    public required string DisabledReason { get; set; }

    /// <summary>
    /// Whether events are being delivered
    /// </summary>
    [JsonPropertyName("enabled")]
    public required bool Enabled { get; set; }

    /// <summary>
    /// The event, when there is exactly one (kept for older integrations)
    /// </summary>
    [JsonPropertyName("event")]
    public required string Event { get; set; }

    /// <summary>
    /// Events delivered to this URL, or `["*"]` for every event
    /// </summary>
    [JsonPropertyName("events")]
    public IEnumerable<string> Events { get; set; } = new List<string>();

    /// <summary>
    /// Unique subscription ID
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// ISO 8601 time of the most recent delivery attempt
    /// </summary>
    [JsonPropertyName("last_delivery_at")]
    public required string LastDeliveryAt { get; set; }

    /// <summary>
    /// Why the most recent attempt failed
    /// </summary>
    [JsonPropertyName("last_delivery_error")]
    public required string LastDeliveryError { get; set; }

    /// <summary>
    /// HTTP status your URL returned on the most recent attempt
    /// </summary>
    [JsonPropertyName("last_delivery_status")]
    public required double LastDeliveryStatus { get; set; }

    /// <summary>
    /// `envelope` (default) or `flat` (the bare data object, used by Zapier)
    /// </summary>
    [JsonPropertyName("payload_format")]
    public required string PayloadFormat { get; set; }

    /// <summary>
    /// URL that receives the POST requests
    /// </summary>
    [JsonPropertyName("target_url")]
    public required string TargetUrl { get; set; }

    /// <summary>
    /// ISO 8601 last-update timestamp
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; set; }

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
