using efcorePro.Models;
using Microsoft.AspNetCore.Mvc;

namespace efcorePro.Controllers
{
    public class CommonController : Controller
    {
        public readonly DatabaseContext _context;
        public CommonController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult AllData(RegisterModel? ob1, EmployeeModel? ob2) 
        {
            var tblres = from s in _context.RegisterModels select s;
            //IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
            var empres = from s in _context.EmployeeModels orderby s.Eid ascending select s ;
            return View(empres.ToList());
        }
    }
}
