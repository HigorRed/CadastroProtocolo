using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProtocoloFollow
{
    [Key]
    public int IdFollow { get; set; }


    public int ProtocoloId { get; set; }

    [ForeignKey("ProtocoloId")]
    public Protocolo Protocolo { get; set; }

    public DateTime DataAcao { get; set; }

  
    public string DescricaoAcao { get; set; }
}
