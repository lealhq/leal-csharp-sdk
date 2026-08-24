using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record ListCustomersRequest
{
    /// <summary>
    /// Store (account) ID
    /// </summary>
    [JsonIgnore]
    public required int AccountId { get; set; }

    /// <summary>
    /// Search query to filter customers by name, email, phone, card code (barcode), or external reference ID
    /// </summary>
    [JsonIgnore]
    public string? Search { get; set; }

    /// <summary>
    /// External system slug (e.g. `square`, `shopify`). When combined with `external_id`, performs an exact lookup.
    /// </summary>
    [JsonIgnore]
    public string? Source { get; set; }

    /// <summary>
    /// External system's identifier for the customer. Must be combined with `source`.
    /// </summary>
    [JsonIgnore]
    public string? ExternalId { get; set; }

    /// <summary>
    /// Page number (defaults to 1)
    /// </summary>
    [JsonIgnore]
    public int? Page { get; set; }

    /// <summary>
    /// Number of items per page
    /// </summary>
    [JsonIgnore]
    public int? Items { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
