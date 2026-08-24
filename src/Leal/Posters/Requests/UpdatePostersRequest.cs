using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record UpdatePostersRequest
{
    /// <summary>
    /// Store (account) ID
    /// </summary>
    [JsonIgnore]
    public required int AccountId { get; set; }

    /// <summary>
    /// Poster ID
    /// </summary>
    [JsonIgnore]
    public required int Id { get; set; }

    [JsonPropertyName("poster")]
    public required UpdatePostersRequestPoster Poster { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
