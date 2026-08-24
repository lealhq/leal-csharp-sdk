using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record CreateCustomersRequestCustomer : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Customer's birthday (YYYY-MM-DD)
    /// </summary>
    [JsonPropertyName("birthday")]
    public string? Birthday { get; set; }

    /// <summary>
    /// Customer's email address (unique per store; required if phone is blank)
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Array of `{source, external_id, metadata}` objects linking this customer to records in external systems
    /// </summary>
    [JsonPropertyName("external_references")]
    public IEnumerable<string>? ExternalReferences { get; set; }

    /// <summary>
    /// Customer's first name
    /// </summary>
    [JsonPropertyName("first_name")]
    public required string FirstName { get; set; }

    /// <summary>
    /// Customer's last name
    /// </summary>
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    /// <summary>
    /// Free-form JSON object of additional per-customer attributes
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    /// <summary>
    /// Customer's phone number (unique per store; required if email is blank)
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

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
