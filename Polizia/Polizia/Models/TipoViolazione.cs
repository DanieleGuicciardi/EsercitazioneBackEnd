using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class TipoViolazione
{
    [Key]
    public int IdViolazione { get; set; }

    [Required]
    public string Descrizione { get; set; }

    
    public List<Verbale>? Verbali { get; set; }
}
