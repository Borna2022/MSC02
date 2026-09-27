using Microsoft.AspNetCore.Mvc;
using MSC02.Data;

namespace MSC02.Controllers
{
    public class HeatController : Controller
    {

        //اینجکت کردن ابجکت دیپندنسی اینجکش یعنی تغییرات کلاس اصلی کاهش وابستگی خواهیم داشت
        private readonly AppDbContext _DbContext;

        public HeatController(AppDbContext DbContext)
        {
            _DbContext = DbContext;

        }

        public IActionResult Index() //همه اکشنها رو پوشش میدهد انواع دیگر 
        {
            var HeatsList = _DbContext.Heats.ToList();
            return View(HeatsList); // پاس دادن ابجکت به سمت ویو
        }
        public IActionResult Create() 
        {
            return View();
        }

    }
}
