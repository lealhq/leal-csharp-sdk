using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record StampCustomerCardsResponseReferredBy : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The inviting customer's card
    /// </summary>
    [JsonPropertyName("customer_card_id")]
    public required double CustomerCardId { get; set; }

    /// <summary>
    /// The customer who invited them
    /// </summary>
    [JsonPropertyName("customer_id")]
    public required int CustomerId { get; set; }

    /// <summary>
    /// Referral ID
    /// </summary>
    [JsonPropertyName("referral_id")]
    public required double ReferralId { get; set; }

    /// <summary>
    /// ISO 8601 timestamp the referral paid out
    /// </summary>
    [JsonPropertyName("rewarded_at")]
    public required string RewardedAt { get; set; }

    /// <summary>
    /// 'pending' until the store first stamps this card for a visit, then 'rewarded'
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
