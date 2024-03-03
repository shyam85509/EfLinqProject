using efcorePro.Models;
using Microsoft.AspNetCore.Mvc;

namespace efcorePro.Controllers
{
    public class EmpController : Controller
    {
        public readonly DatabaseContext _context;
        public EmpController(DatabaseContext context) 
        {
            _context = context;
        }

        public IActionResult RegisterEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterEmployee(EmployeeModel obj)
        {
            if (obj != null) 
            {
                var res = new EmployeeModel
                {
                    Ename = obj.Ename,
                    EmailId = obj.EmailId,
                    Password = obj.Password,
                    dob = Convert.ToDateTime(obj.dob),
                    Eid = Convert.ToInt32(obj.Eid),
                    Salary = Convert.ToDecimal(obj.Salary),
                };
                _context.Add(res);
                int x = _context.SaveChanges();
                if(x > 0)
                {
                    return RedirectToAction("ShowEmp", "Emp");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        public IActionResult ShowEmp(EmployeeModel obj)
        {
            //var res = from s in _context.EmployeeModels select s;
            //var res = from s in _context.EmployeeModels orderby s.Salary select s;
            //var res = (from s in _context.EmployeeModels select s).OrderBy(s => s.Salary).ThenBy(s => s.Ename);
            var res = (from s in _context.EmployeeModels select s).Take(3).ToList();
            return View(res.ToList());
        }

    }
}
