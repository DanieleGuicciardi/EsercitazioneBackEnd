using Microsoft.AspNetCore.Mvc;
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

    public async Task<IActionResult> Index()
    {
        var verbali = _context.Verbali
            .Include(v => v.Anagrafica)
            .Include(v => v.TipoViolazione)
            .ToListAsync();

        return View(await verbali);
    }

    public IActionResult Create()
    {
        ViewBag.Anagrafiche = _context.Anagrafica.ToList();
        ViewBag.TipiViolazione = _context.TipiViolazione.ToList();
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
        return View(verbale);
    }
}
