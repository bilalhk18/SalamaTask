using BilalTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BilalTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestTaskContext _context;

        public HomeController(TestTaskContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewModel model = new();
            foreach (var country in _context.Carmakes)
            {
                model.cm.Add(new SelectListItem { Text = country.MakeName, Value = country.MakeId.ToString() });
            }
            var btypes = (from mod in _context.BodyTypes
                          select mod).ToList();
            foreach (var mod in btypes)
            {
                model.carMol.Add(new SelectListItem { Text = mod.TypeName, Value = mod.TypeId.ToString() });
            }
            var trims = (from mod in _context.CarTrims
                         select mod).ToList();
            foreach (var mod in trims)
            {
                model.carMol.Add(new SelectListItem { Text = mod.TrimName, Value = mod.TrimId.ToString() });
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(int? makeID)
        {
            ViewModel model = new();
            foreach (var country in _context.Carmakes)
            {
                model.cm.Add(new SelectListItem { Text = country.MakeName, Value = country.MakeId.ToString() });
            }

            if (makeID.HasValue)
            {
                var carMods = (from mod in _context.CarModels
                              where mod.MakeId == makeID.Value
                              select mod).ToList();
                foreach (var mod in carMods)
                {
                    model.carMol.Add(new SelectListItem { Text = mod.ModelName, Value = mod.ModelId.ToString() });
                }

            }
            var btypes = (from mod in _context.BodyTypes
                           select mod).ToList();
            foreach (var mod in btypes)
            {
                model.body.Add(new SelectListItem { Text = mod.TypeName, Value = mod.TypeId.ToString() });
            }
            var trims = (from mod in _context.CarTrims
                           select mod).ToList();
            foreach (var mod in trims)
            {
                model.carTrim.Add(new SelectListItem { Text = mod.TrimName, Value = mod.TrimId.ToString() });
            }
            return View(model);
        }
        public IActionResult Privacy()
        {
            var model = (from mod in _context.BenefitsGrids
                         select mod).ToList();
            return View(model);
        }

        
    }
}
