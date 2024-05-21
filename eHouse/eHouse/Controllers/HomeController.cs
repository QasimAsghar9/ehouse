using eHouse.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using eHouse.Repository;
using System.Data;

namespace eHouse.Controllers
{
    public class HomeController : Controller

    {
        //public enum JsonRequestBehavior { }
        Rentdb rdb=new Rentdb();
        private readonly RentRepository _rentRepository=null;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _rentRepository = new RentRepository();

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Buy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Rent(inputModel input, int PageNumber = 1)
        {

            var data = rdb.GetDataHouse();
            var datas = rdb.GetDataHouse();
            var Data = rdb.GetDataHouse();

            ViewBag.Data = datas.ToList().Take(7);

            ViewBag.Datas = Data.Where(x => x.areaUnit == input.areaunit && x.area <= input.max && x.area >= input.min && x.price >= input.minp && x.price <= input.maxp).ToList();
            ViewBag.Totalpages = Math.Ceiling(data.Count() / 6.0);
            if (!string.IsNullOrEmpty(input.areaunit))
            {
                 data = data.Where(x => x.areaUnit == input.areaunit && x.area <= input.max && x.area >= input.min && x.price >= input.minp && x.price <= input.maxp).ToList();
            }

           
            data = data.Skip((PageNumber - 1) * 6).Take(6).ToList();
            var viewModel = new RentModel
            {
                Data = data,
                //SearchList =   List<string>(),
                Input = new inputModel(),
            };
            return View(viewModel);
           
        }
        [HttpPost]
        public IActionResult ajaxRent( int id )
        {
            List<string> errors = new List<string>();
            rdb.favlist(id);

            return Json(errors);
        }
        [HttpPost]
        public IActionResult deleteRent(int id)
        {
            List<string> errors = new List<string>();
            rdb.dellist(id);
            rdb.delimg(id);

            return Json(errors);
        }
        public IActionResult Projects()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult AddProperty()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Banglow(inputModel input, int PageNumber = 1)
        {
            var data = rdb.GetDataBanglow();
            var datas = rdb.GetDataBanglow();
            ViewBag.Data = datas.ToList().Take(6);
            ViewBag.Totalpages = Math.Ceiling(data.Count() / 6.0);
            if (!string.IsNullOrEmpty(input.areaunit))
            {
                data = data.Where(x => x.areaUnit == input.areaunit && x.area <= input.max && x.area >= input.min && x.price <= input.price).ToList();
            }
            data = data.Skip((PageNumber - 1) * 6).Take(6).ToList();
            var viewModel = new RentModel
            {
                Data = data,
                //SearchList =   List<string>(),
                Input = new inputModel(),
            };
            return View(viewModel);
            
        }
        public IActionResult Villas(inputModel input, int PageNumber = 1)
        {
            var data = rdb.GetDataVillas();
            var datas = rdb.GetDataVillas();
            ViewBag.Data = datas.ToList().Take(5);
            ViewBag.Totalpages = Math.Ceiling(data.Count() / 6.0);
            if (!string.IsNullOrEmpty(input.areaunit))
            {
                data = data.Where(x => x.areaUnit == input.areaunit && x.area <= input.max && x.area >= input.min && x.price <= input.price).ToList();
            }
            data = data.Skip((PageNumber - 1) * 6).Take(6).ToList();
            var viewModel = new RentModel
            {
                Data = data,
                //SearchList =   List<string>(),
                Input = new inputModel(),
            };
            return View(viewModel);
           
            
        }
        public IActionResult Apartments(inputModel input, int PageNumber = 1)
        {
            var data = rdb.GetDataApartment();
            var datas = rdb.GetDataApartment();
            ViewBag.Data = datas.ToList().Take(5);
            ViewBag.Totalpages = Math.Ceiling(data.Count() / 6.0);
            if (!string.IsNullOrEmpty(input.areaunit))
            {
                data = data.Where(x => x.areaUnit == input.areaunit && x.area <= input.max && x.area >= input.min && x.price <= input.price).ToList();
            }
            data = data.Skip((PageNumber - 1) * 6).Take(6).ToList();
            var viewModel = new RentModel
            {
                Data = data,
                //SearchList =   List<string>(),
                Input = new inputModel(),
            };
            return View(viewModel);
            
        }
        public IActionResult Building(inputModel input, int PageNumber = 1)
        {
            var data = rdb.GetDataBuilding();
            var datas = rdb.GetDataBuilding();
            ViewBag.Data = datas.ToList().Take(5);
            ViewBag.Totalpages = Math.Ceiling(data.Count() / 6.0);
            if (!string.IsNullOrEmpty(input.areaunit))
            {
                data = data.Where(x => x.areaUnit == input.areaunit && x.area <= input.max && x.area >= input.min && x.price <= input.maxp &&x.price>=input.minp).ToList();
            }
            data = data.Skip((PageNumber - 1) * 6).Take(6).ToList();
            var viewModel = new RentModel
            {
                Data = data,
                //SearchList =   List<string>(),
                Input = new inputModel(),
            };
            return View(viewModel);
        }
        public IActionResult Industrial(inputModel input, int PageNumber = 1)
        {
            var data = rdb.GetDataIndustrial();
            var datas = rdb.GetDataIndustrial();
            ViewBag.Data = datas.ToList().Take(5);
            ViewBag.Totalpages = Math.Ceiling(data.Count() / 6.0);
            if (!string.IsNullOrEmpty(input.areaunit))
            {
                data = data.Where(x => x.areaUnit == input.areaunit && x.area <= input.max && x.area >= input.min && x.price <= input.price).ToList();
            }
            data = data.Skip((PageNumber - 1) * 6).Take(6).ToList();
            var viewModel = new RentModel
            {
                Data = data,
                //SearchList =   List<string>(),
                Input = new inputModel(),
            };
            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}