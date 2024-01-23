using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ApiController : Controller
    {
        private readonly MyDBContext _dbContext;
        
        public ApiController(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            System.Threading.Thread.Sleep(5000);
            //return Content("Hello Content")
            //return Content("<h2>Content, 您好</h2>","text/plain");
            return Content("<h2>Content, 您好</h2>","text/plain",System.Text.Encoding.UTF8); //Content用法
        }
   
        public IActionResult Cities()
        {
            var cities = _dbContext.Addresses.Select(x => x.City).Distinct();
            return Json(cities);
        }
        public IActionResult Avatar(int id = 1)
        {
            Member? member = _dbContext.Members.Find(id);
            if (member != null)
            {
                byte[] img = member.FileData;
                return File(img, "image/jpeg"); //File用法
            }
            return NotFound();
        }
        public IActionResult CheckAccount(string account)
        {
            var IsExistsData = _dbContext.Members.Any(x=>x.Name == account);

            return Json(IsExistsData);
        }
        public IActionResult FormReturnData(string name, string email,int age)
        {
            return Json(new { Name = name, Email = email ,Age = age});
        }
 
    }
}
