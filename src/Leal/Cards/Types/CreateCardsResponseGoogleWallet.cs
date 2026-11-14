using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record CreateCardsResponseGoogleWallet : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// What fills the hero image behind the stamps: 'hero_image' (uploaded in Leal), 'strip_image', 'preset' or 'color'
    /// </summary>
    [JsonPropertyName("hero_image")]
    public required string HeroImage { get; set; }

    /// <summary>
    /// The text colour Google Wallet uses on this card: it picks black or white itself and ignores text_color
    /// </summary>
    [JsonPropertyName("text_color")]
    public required string TextColor { get; set; }

    /// <summary>
    /// Guidelines the card doesn't meet: any of 'color', 'title', 'issuer_name', 'field_labels', 'field_values', 'logo', 'hero'. Empty when it meets them all
    /// </summary>
    [JsonPropertyName("warnings")]
    public IEnumerable<string> Warnings { get; set; } = new List<string>();

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
