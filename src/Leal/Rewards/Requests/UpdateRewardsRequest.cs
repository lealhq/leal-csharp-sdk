using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record UpdateRewardsRequest
{
    /// <summary>
    /// Store (account) ID
    /// </summary>
    [JsonIgnore]
    public required int AccountId { get; set; }

    /// <summary>
    /// Reward ID
    /// </summary>
    [JsonIgnore]
    public required int Id { get; set; }

    [JsonPropertyName("reward")]
    public required UpdateRewardsRequestReward Reward { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
