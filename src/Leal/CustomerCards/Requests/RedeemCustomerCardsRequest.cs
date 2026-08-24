using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record RedeemCustomerCardsRequest
{
    /// <summary>
    /// Store (account) ID
    /// </summary>
    [JsonIgnore]
    public required int AccountId { get; set; }

    /// <summary>
    /// Customer ID
    /// </summary>
    [JsonIgnore]
    public required int CustomerId { get; set; }

    /// <summary>
    /// Customer card ID
    /// </summary>
    [JsonIgnore]
    public required int Id { get; set; }

    /// <summary>
    /// Reward ID to redeem
    /// </summary>
    [JsonPropertyName("reward_id")]
    public required int RewardId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
