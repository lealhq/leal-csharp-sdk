using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record PostApiV1AccountsAccountIdWebhookSubscriptionsRequest
{
    /// <summary>
    /// Store (account) ID
    /// </summary>
    [JsonIgnore]
    public required int AccountId { get; set; }

    /// <summary>
    /// Your own label, up to 255 characters
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Create the subscription disabled by passing false (defaults to true)
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// A single event to subscribe to. Same as `events` with one entry
    /// </summary>
    [JsonPropertyName("event")]
    public string? Event { get; set; }

    /// <summary>
    /// Events to subscribe to, or `["*"]` for every event. Required unless `event` is given
    /// </summary>
    [JsonPropertyName("events")]
    public IEnumerable<string>? Events { get; set; }

    /// <summary>
    /// `envelope` (default) or `flat`. `flat` sends the bare data object and cannot be combined with `*`
    /// </summary>
    [JsonPropertyName("payload_format")]
    public string? PayloadFormat { get; set; }

    /// <summary>
    /// Public https URL that will receive the POST requests
    /// </summary>
    [JsonPropertyName("target_url")]
    public required string TargetUrl { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
