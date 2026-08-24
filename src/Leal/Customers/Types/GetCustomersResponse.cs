using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record GetCustomersResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Parent store ID
    /// </summary>
    [JsonPropertyName("account_id")]
    public required int AccountId { get; set; }

    /// <summary>
    /// Birthday as YYYY-MM-DD
    /// </summary>
    [JsonPropertyName("birthday")]
    public required string Birthday { get; set; }

    /// <summary>
    /// ISO 8601 creation timestamp
    /// </summary>
    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    /// <summary>
    /// Cards this customer is enrolled on
    /// </summary>
    [JsonPropertyName("customer_cards")]
    public IEnumerable<string> CustomerCards { get; set; } = new List<string>();

    /// <summary>
    /// Email address, unique per store
    /// </summary>
    [JsonPropertyName("email")]
    public required string Email { get; set; }

    /// <summary>
    /// Links to records in other systems
    /// </summary>
    [JsonPropertyName("external_references")]
    public IEnumerable<string> ExternalReferences { get; set; } = new List<string>();

    /// <summary>
    /// First name
    /// </summary>
    [JsonPropertyName("first_name")]
    public required string FirstName { get; set; }

    /// <summary>
    /// Unique customer ID
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Last name
    /// </summary>
    [JsonPropertyName("last_name")]
    public required string LastName { get; set; }

    /// <summary>
    /// Free form per customer data
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?> Metadata { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// Phone number, unique per store
    /// </summary>
    [JsonPropertyName("phone")]
    public required string Phone { get; set; }

    /// <summary>
    /// Total stamps across every card
    /// </summary>
    [JsonPropertyName("stamp_count")]
    public required int StampCount { get; set; }

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
