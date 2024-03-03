using efcorePro.Models;
using Microsoft.AspNetCore.Mvc;

namespace efcorePro.Controllers
{
    public class enumandquriableController : Controller
    {
        public readonly DatabaseContext _context;
        public enumandquriableController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult enumView(EmployeeModel obj, string Name)
        {
            //var res = from s in _context.EmployeeModels select s;
            //IEnumerable<EmployeeModel> res = from s in _context.EmployeeModels where s.Ename == "Shyam" select s; 
            IQueryable<EmployeeModel> res = from s in _context.EmployeeModels.AsQueryable() select s;

            return View(res.ToList());
        }
    }
}
