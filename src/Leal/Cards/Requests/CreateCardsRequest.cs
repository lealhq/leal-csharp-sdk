using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record CreateCardsRequest
{
    /// <summary>
    /// Parent store ID
    /// </summary>
    [JsonIgnore]
    public required int AccountId { get; set; }

    [JsonPropertyName("card")]
    public required CreateCardsRequestCard Card { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
