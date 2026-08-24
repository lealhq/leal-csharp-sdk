using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record ListCardsResponseItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ISO 8601 timestamp when the card was archived, or null if active
    /// </summary>
    [JsonPropertyName("archived_at")]
    public required string ArchivedAt { get; set; }

    /// <summary>
    /// Hex colour for the card background (e.g. '#6B4226')
    /// </summary>
    [JsonPropertyName("card_color")]
    public required string CardColor { get; set; }

    /// <summary>
    /// ISO 8601 creation timestamp
    /// </summary>
    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    /// <summary>
    /// Number of customer card instances issued
    /// </summary>
    [JsonPropertyName("customer_cards_count")]
    public required int CustomerCardsCount { get; set; }

    /// <summary>
    /// Optional header text displayed on the card
    /// </summary>
    [JsonPropertyName("header_text")]
    public required string HeaderText { get; set; }

    /// <summary>
    /// Unique card ID
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Number of stamps pre-filled on new customer cards (0 to stamps_required - 1)
    /// </summary>
    [JsonPropertyName("initial_stamps")]
    public required int InitialStamps { get; set; }

    /// <summary>
    /// Card name (e.g. 'Coffee Loyalty Card')
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Number of rewards defined for this card
    /// </summary>
    [JsonPropertyName("rewards_count")]
    public required int RewardsCount { get; set; }

    /// <summary>
    /// Hex colour for stamp backgrounds
    /// </summary>
    [JsonPropertyName("stamp_background_color")]
    public required string StampBackgroundColor { get; set; }

    /// <summary>
    /// Hex colour for stamp icons
    /// </summary>
    [JsonPropertyName("stamp_color")]
    public required string StampColor { get; set; }

    /// <summary>
    /// Icon used for stamps (e.g. 'coffee', 'heart', 'star')
    /// </summary>
    [JsonPropertyName("stamp_icon")]
    public required string StampIcon { get; set; }

    /// <summary>
    /// Number of stamps needed to complete the card (1–21)
    /// </summary>
    [JsonPropertyName("stamps_required")]
    public required int StampsRequired { get; set; }

    /// <summary>
    /// Hex colour for the strip (when strip_type is 'color')
    /// </summary>
    [JsonPropertyName("strip_color")]
    public required string StripColor { get; set; }

    /// <summary>
    /// Preset strip image identifier (when strip_type is 'preset')
    /// </summary>
    [JsonPropertyName("strip_preset")]
    public required string StripPreset { get; set; }

    /// <summary>
    /// Strip image type: 'color', 'image', or 'preset'
    /// </summary>
    [JsonPropertyName("strip_type")]
    public required string StripType { get; set; }

    /// <summary>
    /// Hex colour for card text
    /// </summary>
    [JsonPropertyName("text_color")]
    public required string TextColor { get; set; }

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
