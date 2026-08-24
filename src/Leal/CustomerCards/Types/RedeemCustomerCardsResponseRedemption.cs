using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record RedeemCustomerCardsResponseRedemption : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Redemption ID
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// ISO 8601 timestamp of the redemption
    /// </summary>
    [JsonPropertyName("redeemed_at")]
    public required string RedeemedAt { get; set; }

    /// <summary>
    /// Reward that was redeemed
    /// </summary>
    [JsonPropertyName("reward_id")]
    public required int RewardId { get; set; }

    /// <summary>
    /// Display name of the reward
    /// </summary>
    [JsonPropertyName("reward_name")]
    public required string RewardName { get; set; }

    /// <summary>
    /// Stamps left on the card afterwards
    /// </summary>
    [JsonPropertyName("stamps_remaining")]
    public required int StampsRemaining { get; set; }

    /// <summary>
    /// Stamps deducted from the card
    /// </summary>
    [JsonPropertyName("stamps_spent")]
    public required int StampsSpent { get; set; }

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
