using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record StampCustomerCardsRequest
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
    /// When true, stamp changes bypass notifications
    /// </summary>
    [JsonPropertyName("skip_notifications")]
    public bool? SkipNotifications { get; set; }

    /// <summary>
    /// Number of stamps to add (e.g. 1, 3)
    /// </summary>
    [JsonPropertyName("stamps")]
    public required int Stamps { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
