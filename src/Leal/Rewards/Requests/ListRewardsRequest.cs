using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record ListRewardsRequest
{
    /// <summary>
    /// Store (account) ID
    /// </summary>
    [JsonIgnore]
    public required int AccountId { get; set; }

    /// <summary>
    /// Filter rewards belonging to a specific card
    /// </summary>
    [JsonIgnore]
    public int? CardId { get; set; }

    /// <summary>
    /// When present, return only active rewards
    /// </summary>
    [JsonIgnore]
    public string? Active { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
