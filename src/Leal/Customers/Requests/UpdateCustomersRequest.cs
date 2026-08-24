using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record UpdateCustomersRequest
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
    public required int Id { get; set; }

    [JsonPropertyName("customer")]
    public required UpdateCustomersRequestCustomer Customer { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
