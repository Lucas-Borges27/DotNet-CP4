using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToyAPI.DTOs;

public class BrinquedoCreateDto
{
    [Required]
    [MaxLength(120)]
    [JsonPropertyName("nome_brinquedo")]
    public string NomeBrinquedo { get; set; } = string.Empty;

    [Required]
    [MaxLength(60)]
    [JsonPropertyName("tipo_brinquedo")]
    public string TipoBrinquedo { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    [JsonPropertyName("classificacao")]
    public string Classificacao { get; set; } = string.Empty;

    [Required]
    [MaxLength(30)]
    [JsonPropertyName("tamanho")]
    public string Tamanho { get; set; } = string.Empty;

    [Range(0.01, 100000)]
    [JsonPropertyName("preco")]
    public decimal Preco { get; set; }
}
