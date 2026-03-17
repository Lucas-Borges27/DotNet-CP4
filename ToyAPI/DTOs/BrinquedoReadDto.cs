using System.Text.Json.Serialization;

namespace ToyAPI.DTOs;

public class BrinquedoReadDto
{
    [JsonPropertyName("id_brinquedo")]
    public int IdBrinquedo { get; set; }

    [JsonPropertyName("nome_brinquedo")]
    public string NomeBrinquedo { get; set; } = string.Empty;

    [JsonPropertyName("tipo_brinquedo")]
    public string TipoBrinquedo { get; set; } = string.Empty;

    [JsonPropertyName("classificacao")]
    public string Classificacao { get; set; } = string.Empty;

    [JsonPropertyName("tamanho")]
    public string Tamanho { get; set; } = string.Empty;

    [JsonPropertyName("preco")]
    public decimal Preco { get; set; }
}
