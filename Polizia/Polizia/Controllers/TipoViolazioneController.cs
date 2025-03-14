using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class TipoViolazioneController : Controller
{
    private readonly AppDbContext _context;

    public TipoViolazioneController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.TipiViolazione.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TipoViolazione violazione)
    {
        if (ModelState.IsValid)
        {
            _context.Add(violazione);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(violazione);
    }
}
