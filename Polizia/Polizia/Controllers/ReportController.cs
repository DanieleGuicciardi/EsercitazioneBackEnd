using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class ReportController : Controller
{
    private readonly AppDbContext _context;

    public ReportController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> TotaleVerbaliPerTrasgressore()
    {
        var data = await _context.Verbale
            .GroupBy(v => v.Anagrafica.Cognome)
            .Select(g => new
            {
                Trasgressore = g.Key,
                TotaleVerbali = g.Count()
            })
            .ToListAsync();

        return View(data);
    }

    public async Task<IActionResult> TotalePuntiDecurtati()
    {
        var data = await _context.Verbale
            .GroupBy(v => v.Anagrafica.Cognome)
            .Select(g => new
            {
                Trasgressore = g.Key,
                PuntiDecurtati = g.Sum(v => v.DecurtamentoPunti)
            })
            .ToListAsync();

        return View(data);
    }

    public async Task<IActionResult> ViolazioniGravi()
    {
        var data = await _context.Verbale
            .Where(v => v.DecurtamentoPunti > 10)
            .Select(v => new
            {
                v.Anagrafica.Cognome,
                v.Anagrafica.Nome,
                v.DataViolazione,
                v.Importo,
                v.DecurtamentoPunti
            })
            .ToListAsync();

        return View(data);
    }

    public async Task<IActionResult> ViolazioniCostose()
    {
        var data = await _context.Verbale
            .Where(v => v.Importo > 400)
            .Select(v => new
            {
                v.Anagrafica.Cognome,
                v.Anagrafica.Nome,
                v.DataViolazione,
                v.Importo,
                v.DecurtamentoPunti
            })
            .ToListAsync();

        return View(data);
    }
}

