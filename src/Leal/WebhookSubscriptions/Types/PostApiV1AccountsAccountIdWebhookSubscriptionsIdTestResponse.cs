using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record PostApiV1AccountsAccountIdWebhookSubscriptionsIdTestResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// True when your URL responded with a 2xx status
    /// </summary>
    [JsonPropertyName("delivered")]
    public required bool Delivered { get; set; }

    /// <summary>
    /// Why the delivery failed
    /// </summary>
    [JsonPropertyName("error")]
    public required string Error { get; set; }

    /// <summary>
    /// The `webhook-id` of the test event
    /// </summary>
    [JsonPropertyName("event_id")]
    public required string EventId { get; set; }

    /// <summary>
    /// HTTP status your URL returned
    /// </summary>
    [JsonPropertyName("status")]
    public required double Status { get; set; }

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
