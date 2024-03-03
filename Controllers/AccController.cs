using efcorePro.Models;
using Microsoft.AspNetCore.Mvc;

namespace efcorePro.Controllers
{
    public class AccController : Controller
    {
        public readonly DatabaseContext _context;
        public AccController(DatabaseContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Massage = "Please Enter Email and Password...... !!";
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel obj)
        {
            var res = _context.RegisterModels.Any(val => val.Email == obj.Email && val.Password == obj.Password);
            if(res == true)
            {
                return RedirectToAction("DisplayData","Acc");
            }
            else
            {
                ViewBag.Massage = "Enter Email and Password";
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult searchData(string Name, int Rollno)
        {
            return View();
        }
        [HttpPost]
        public IActionResult searchData(RegisterModel obj)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Register(RegisterModel obj)
        {
            if(obj == null)
            {

            }
            else
            {
                if(ModelState.IsValid)
                {
                    var res = new RegisterModel
                    {
                        Rollno = Convert.ToInt32(obj.Rollno),
                        Name = obj.Name,
                        Email = obj.Email,
                        Password = obj.Password,
                        DOB = Convert.ToDateTime(obj.DOB),
                        Mobile = obj.Mobile,
                        Gender = obj.Gender,
                        Fee = Convert.ToDecimal(obj.Fee),
                        Dept = obj.Dept,
                        Status = Convert.ToBoolean(obj.Status)
                    };
                    _context.Add(res);
                    int x = _context.SaveChanges();
                    if (x > 0)
                    {
                        return RedirectToAction("Home", "Acc");
                    }
                }
            }
            return View();
        }

        public IActionResult DisplayData()
        {
            /* var res = from s in _context.RegisterModels where s.Gender=="Male" select s;
            var res = from s in _context.RegisterModels select s;

            var res = from s in _context.RegisterModels select new RegisterModel {
                Rollno = s.Rollno,
                Name = s.Name,
                Email = s.Email,
            }; */ 
            //var res = from s in _context.RegisterModels where s.Email == "Timbu@test.com" && s.Password == "Timbu211" select s;
            var res = (from s in _context.RegisterModels select s).Distinct();

            return View(res.ToList());
        }

        [HttpGet]
        public IActionResult Views(int? Id)
        {
            var data = _context.RegisterModels.Find(Id);
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            var data = _context.RegisterModels.Find(Id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(int? Id, RegisterModel obj)
        {
            if(obj == null)
            {

            }
            else
            {
                if(ModelState.IsValid)
                {
                    _context.Update(obj);
                    int x = _context.SaveChanges();
                    if (x > 0)
                    {
                        return RedirectToAction("DisplayData", "Acc");
                    }
                }
            }
            return View();
        }
        public IActionResult Delete(int? Id)
        {
            var data = _context.RegisterModels.Find(Id);
            if(data != null)
            {
                _context.RegisterModels.Remove(data);
                int x = _context.SaveChanges();
                if(x > 0)
                {
                    return RedirectToAction("DisplayData", "Acc");
                }
            }
            return View();
        }
    }
}
