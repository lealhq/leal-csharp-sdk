using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record CreatePostersRequestPoster : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether the poster is active (defaults to true)
    /// </summary>
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    /// <summary>
    /// ID of the loyalty card this poster links to
    /// </summary>
    [JsonPropertyName("card_id")]
    public required int CardId { get; set; }

    /// <summary>
    /// Print size – one of: a4, a5, a6, letter
    /// </summary>
    [JsonPropertyName("paper_size")]
    public string? PaperSize { get; set; }

    /// <summary>
    /// Primary brand color as a hex string (e.g. '#FF5733')
    /// </summary>
    [JsonPropertyName("primary_color")]
    public string? PrimaryColor { get; set; }

    /// <summary>
    /// Secondary brand color as a hex string
    /// </summary>
    [JsonPropertyName("secondary_color")]
    public string? SecondaryColor { get; set; }

    /// <summary>
    /// Text color as a hex string
    /// </summary>
    [JsonPropertyName("text_color")]
    public string? TextColor { get; set; }

    /// <summary>
    /// Headline text displayed on the poster
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

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
