using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record GetRewardsResponse : IJsonOnDeserialized
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
    /// Whether the reward can currently be redeemed
    /// </summary>
    [JsonPropertyName("active")]
    public required bool Active { get; set; }

    /// <summary>
    /// ID of the loyalty card this reward belongs to
    /// </summary>
    [JsonPropertyName("card_id")]
    public required int CardId { get; set; }

    /// <summary>
    /// ISO 8601 creation timestamp
    /// </summary>
    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    /// <summary>
    /// Longer description of the reward
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// Unique reward ID
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Display name of the reward
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Display order
    /// </summary>
    [JsonPropertyName("position")]
    public required int Position { get; set; }

    /// <summary>
    /// Stamps needed before the reward can be redeemed
    /// </summary>
    [JsonPropertyName("stamps_required")]
    public required int StampsRequired { get; set; }

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
