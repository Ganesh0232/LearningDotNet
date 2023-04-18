using Microsoft.AspNetCore.Mvc;
using FirstMVCApp.Models;

namespace FirstMVCApp.Controllers
{
    public class PracticeController : Controller
    {
        private static List<LoginViewModel> vm = new List<LoginViewModel>();
        public IActionResult Index()
        {
            //LoginViewModel vm = new LoginViewModel()
            //{
            //    Name="Ganesh",CodeName="G232"
            //};
           
            return View(vm);
        }
        public IActionResult Vieww()
        {
            return View();
        }
        public IActionResult Create()
        {
            var vm = new LoginViewModel();
            return View(vm);
        }
        public IActionResult CreateAgent(LoginViewModel lvm)
        {
            //  return View("Index");
            vm.Add(lvm);

            return RedirectToAction(nameof(Index));
        }
    }
}
