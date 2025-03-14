using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Anagrafica
{
    [Key]
    public int IdAnagrafica { get; set; }

    [Required]
    public string Cognome { get; set; }

    [Required]
    public string Nome { get; set; }

    public string Indirizzo { get; set; }
    public string Citta { get; set; }
    public string CAP { get; set; }
    public string Cod_Fisc { get; set; }

    public List<Verbale>? Verbali { get; set; }
}
