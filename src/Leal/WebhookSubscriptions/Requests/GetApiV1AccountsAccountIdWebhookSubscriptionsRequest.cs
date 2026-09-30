using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record GetApiV1AccountsAccountIdWebhookSubscriptionsRequest
{
    /// <summary>
    /// Store (account) ID
    /// </summary>
    [JsonIgnore]
    public required int AccountId { get; set; }

    /// <summary>
    /// Only return subscriptions that list this event (or `*`)
    /// </summary>
    [JsonIgnore]
    public string? Event { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
