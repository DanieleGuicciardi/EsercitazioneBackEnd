using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class VerbaleController : Controller
{
    private readonly AppDbContext _context;

    public VerbaleController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        ViewBag.Anagrafiche = new SelectList(_context.Anagrafica, "IdAnagrafica", "Cognome");
        ViewBag.TipoViolazione = new SelectList(_context.TipiViolazione, "IdViolazione", "Descrizione");

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Verbale verbale)
    {
        if (ModelState.IsValid)
        {
            _context.Add(verbale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Anagrafiche = new SelectList(_context.Anagrafica, "IdAnagrafica", "Cognome", verbale.IdAnagrafica);
        ViewBag.TipoViolazione = new SelectList(_context.TipiViolazione, "IdViolazione", "Descrizione", verbale.IdViolazione);

        return View(verbale);
    }

    public async Task<IActionResult> Index()
    {
        var verbali = _context.Verbale
            .Include(v => v.Anagrafica)
            .Include(v => v.TipoViolazione)
            .ToListAsync();

        return View(await verbali);
    }
}
