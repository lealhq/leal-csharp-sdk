using global::System.Text.Json.Serialization;
using Leal.Core;

namespace Leal;

[Serializable]
public record UpdateStoresRequest
{
    /// <summary>
    /// Store ID
    /// </summary>
    [JsonIgnore]
    public required int Id { get; set; }

    [JsonPropertyName("account")]
    public required UpdateStoresRequestAccount Account { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
