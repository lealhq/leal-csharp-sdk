using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record ListCustomerCardsRequest
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
