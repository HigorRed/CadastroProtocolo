using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Cliente
{
    [Key] 
    public int IdCliente { get; set; }

    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }

    public ICollection<Protocolo> Protocolos { get; set; } = new List<Protocolo>();
}

