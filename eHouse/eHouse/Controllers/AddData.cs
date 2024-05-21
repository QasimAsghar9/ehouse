using eHouse.Data;
using eHouse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace eHouse.Controllers
{
    public class AddData : Controller
    {
        Rentdb db = new Rentdb();      
        public IActionResult insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult insert([Bind] RentModel rm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string res = db.Saverecord(rm);
                    TempData["msg"] = res;
                }
            }
            catch(Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
    }
}
