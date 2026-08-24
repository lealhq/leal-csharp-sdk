using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record UpdateStoresResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Number of loyalty card templates
    /// </summary>
    [JsonPropertyName("cards_count")]
    public required int CardsCount { get; set; }

    /// <summary>
    /// ISO 8601 creation timestamp
    /// </summary>
    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    /// <summary>
    /// Number of enrolled customers
    /// </summary>
    [JsonPropertyName("customers_count")]
    public required int CustomersCount { get; set; }

    /// <summary>
    /// Resolved display name (store_name if present, otherwise name)
    /// </summary>
    [JsonPropertyName("display_store_name")]
    public required string DisplayStoreName { get; set; }

    /// <summary>
    /// Unique store ID
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Number of physical locations
    /// </summary>
    [JsonPropertyName("locations_count")]
    public required int LocationsCount { get; set; }

    /// <summary>
    /// Internal account name
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Whether this is the user's personal account
    /// </summary>
    [JsonPropertyName("personal")]
    public required bool Personal { get; set; }

    /// <summary>
    /// Number of QR signup posters
    /// </summary>
    [JsonPropertyName("posters_count")]
    public required int PostersCount { get; set; }

    /// <summary>
    /// Public-facing store name
    /// </summary>
    [JsonPropertyName("store_name")]
    public required string StoreName { get; set; }

    /// <summary>
    /// ISO 8601 last-update timestamp
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; set; }

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
