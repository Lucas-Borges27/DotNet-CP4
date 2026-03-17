using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyAPI.Models;

[Table("TDS_TB_Brinquedos")]
public class Brinquedo
{
    [Key]
    [Column("Id_brinquedo")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdBrinquedo { get; set; }

    [Required]
    [Column("Nome_brinquedo")]
    [MaxLength(120)]
    public string NomeBrinquedo { get; set; } = string.Empty;

    [Required]
    [Column("Tipo_brinquedo")]
    [MaxLength(60)]
    public string TipoBrinquedo { get; set; } = string.Empty;

    [Required]
    [Column("Classificacao")]
    [MaxLength(20)]
    public string Classificacao { get; set; } = string.Empty;

    [Required]
    [Column("Tamanho")]
    [MaxLength(30)]
    public string Tamanho { get; set; } = string.Empty;

    [Column("Preco", TypeName = "decimal(10,2)")]
    [Range(0.01, 100000)]
    public decimal Preco { get; set; }
}
