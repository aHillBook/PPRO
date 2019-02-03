using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skoleni.ActionFilters;
using Skoleni.Models;

namespace Skoleni.Controllers
{
    public class PrihlaskyController : Controller
    {
        private readonly DB _context;

        public PrihlaskyController(DB context)
        {
            _context = context;
        }

        [ServiceFilter(typeof(PrihlasenFiltr))]
        public async Task<IActionResult> Index()
        {
            int idUser = (int)HttpContext.Session.GetInt32("roleId");

            var zaznamy = await _context.seznamZaznamu.Include(z => z.termin).Include(z => z.termin.skoleni).Include(z => z.termin.mistnost).Include(z => z.uzivatel)
                            .Where(x => x.idUzivatele == idUser).OrderBy(x => x.termin.terminKonani).ToListAsync();


            ViewData["mainVolba"] = 2;

            return View(zaznamy);
        }

        [ServiceFilter(typeof(PrihlasenFiltr))]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["mainVolba"] = 2;
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var zaznam = await _context.seznamZaznamu.Include(z => z.termin).Include(z => z.termin.skoleni).Include(z => z.termin.mistnost).Include(z => z.uzivatel)
                             .Where(x => x.idZaznamu == id).FirstOrDefaultAsync();

            return View(zaznam);
        }

        [ServiceFilter(typeof(PrihlasenFiltr))]
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["mainVolba"] = 2;
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var zaznam = await _context.seznamZaznamu.Include(z => z.termin).Include(z => z.termin.skoleni).Include(z => z.termin.mistnost).Include(z => z.uzivatel)
                             .Where(x => x.idZaznamu == id).FirstOrDefaultAsync();

            return View(zaznam);
        }

        [ServiceFilter(typeof(PrihlasenFiltr))]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["mainVolba"] = 2;
            var skoleni = await _context.seznamSkoleni.FindAsync(id);
            _context.seznamSkoleni.Remove(skoleni);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}