using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum StatusProtocolo
{
    Aberto,
    EmAndamento,
    Concluido
}

public class Protocolo
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(200)]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    public string Descricao { get; set; } = string.Empty;

    public StatusProtocolo Status { get; set; } = StatusProtocolo.Aberto;

    [ForeignKey("Cliente")]
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }

    public DateTime? DataFechamento { get; set; }  

     public DateTime? DataAbertura { get; set; }  

     
}
