using efcorePro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace efcorePro.Controllers
{
    public class LinqandspEfController : Controller
    {
        public readonly DatabaseContext _context;
        public LinqandspEfController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult InsertData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertData(CountryModel obj)
        {
            List<CountryModel> list;

            string sql = "exec sp_insertvilageDatan @Vname, @Vdist, @PinCode";

            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter{ParameterName="@Vname", Value=obj.Vname},
                new SqlParameter{ParameterName="@Vdist", Value=obj.Vdist},
                new SqlParameter{ParameterName="@PinCode", Value=obj.PinCode}
            };
            var res = _context.Database.ExecuteSqlRaw(sql, param.ToArray());
            if(res > 0)
            {
                return RedirectToAction("Displayvilage", "LinqandspEf");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Displayvilage(CountryModel obj)
        {

            List<CountryModel> List;
            string sql = "exec Sp_displayVilage";
            var res = _context.CountryModels.FromSqlRaw<CountryModel>(sql).ToList();
            //IEnumerable<CountryModel> res = from s in _context.CountryModels select s;
            return View(res.ToList());
        }

        public IActionResult Edit(int? Vid)
        {
            string sql = "exec sp_vilageByIdn @Vid";

            List<SqlParameter> para = new List<SqlParameter>() { 
                new SqlParameter{ParameterName="@Vid", Value = Vid}
            };
            var res = _context.CountryModels.FromSqlRaw(sql, para.ToArray()).AsEnumerable().FirstOrDefault();
            return View(res);
        }

        [HttpPost]
        public IActionResult Edit(CountryModel obj, int? Vid)
        {
            string sql = "exec sp_update_vilageDataById @Vid, @Vname, @Vdist, @pinCode";
            List<SqlParameter> par = new List<SqlParameter>() { 
                new SqlParameter { ParameterName="@Vname", Value=obj.Vname },
                new SqlParameter { ParameterName="@Vdist", Value=obj.Vdist },
                new SqlParameter { ParameterName="@pinCode", Value=obj.PinCode },
                new SqlParameter { ParameterName="@Vid", Value=Vid }
            };

            var res = _context.Database.ExecuteSqlRaw(sql, par.ToArray());
            if(res > 0)
            {
                return RedirectToAction("Displayvilage", "LinqandspEf");
            }
            else
            {
                return View(obj);
            }
        }

        public IActionResult Delete(int? Vid)
        {
            string sql = "exec sp_delete_vilageDataById @Vid";
            List<SqlParameter> id = new List<SqlParameter>()
            {

                new SqlParameter{ParameterName="@Vid", Value=Vid}
            };
            var res = _context.Database.ExecuteSqlRaw(sql,id);
            if(res > 0)
            {
                return RedirectToAction("Displayvilage", "LinqandspEf");                
            }
            else
            {
                return ViewBag.Message = "Not Deleted ....... !";
            }
            return View();
        }
    }
}
