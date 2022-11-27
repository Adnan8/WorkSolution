using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC.Models;
using WS.Business.Base;
using WS.Domain.Model;
using WS.Domain.ViewModels;

namespace WebMVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWorkRepository _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWorkRepository unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<ToDo> productList = _unitOfWork.ToDo.GetAll();

            return View(productList);
        }

        public IActionResult Details(int id)
        {
            ToDoVMTwo cartObj = new()
            {
                Count = 1,
                ToDo = _unitOfWork.ToDo.GetFirstOrDefault(u => u.Id == id),
            };

            return View(cartObj);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
