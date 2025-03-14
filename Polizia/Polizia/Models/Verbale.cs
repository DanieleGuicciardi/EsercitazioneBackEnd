using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

public class Verbale
{
    [Key]
    public int IdVerbale { get; set; }

    [ForeignKey("Anagrafica")]
    public int IdAnagrafica { get; set; }
    public Anagrafica Anagrafica { get; set; }

    [ForeignKey("TipoViolazione")]
    public int IdViolazione { get; set; }
    public TipoViolazione TipoViolazione { get; set; }

    public DateTime DataViolazione { get; set; }
    public string IndirizzoViolazione { get; set; }
    public string Nominativo_Agente { get; set; }
    public DateTime DataTrascrizioneVerbale { get; set; }
    public decimal Importo { get; set; }
    public int DecurtamentoPunti { get; set; }
}
