using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class AnagraficaController : Controller
{
    private readonly AppDbContext _context;

    public AnagraficaController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Anagrafica.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Anagrafica anagrafica)
    {
        if (ModelState.IsValid)
        {
            _context.Add(anagrafica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(anagrafica);
    }
}
