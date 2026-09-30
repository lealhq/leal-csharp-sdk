using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record PatchApiV1AccountsAccountIdWebhookSubscriptionsIdRequest
{
    /// <summary>
    /// Store (account) ID
    /// </summary>
    [JsonIgnore]
    public required int AccountId { get; set; }

    /// <summary>
    /// Webhook subscription ID
    /// </summary>
    [JsonIgnore]
    public required int Id { get; set; }

    /// <summary>
    /// Your own label, up to 255 characters
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// false to pause deliveries, true to resume them
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// A single event. Same as `events` with one entry
    /// </summary>
    [JsonPropertyName("event")]
    public string? Event { get; set; }

    /// <summary>
    /// Replaces the list of events, or `["*"]` for every event
    /// </summary>
    [JsonPropertyName("events")]
    public IEnumerable<string>? Events { get; set; }

    /// <summary>
    /// `envelope` or `flat`
    /// </summary>
    [JsonPropertyName("payload_format")]
    public string? PayloadFormat { get; set; }

    /// <summary>
    /// Public https URL that will receive the POST requests
    /// </summary>
    [JsonPropertyName("target_url")]
    public string? TargetUrl { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
