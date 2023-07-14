using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Linq.Expressions;
using System.Xml.Linq;
using WS.Business.Base;
using WS.Domain.Model;
using WS.Domain.ViewModels;
using WS.Utility;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
    public class ToDoHistoryController : Controller
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;


        public ToDoHistoryController(IUnitOfWorkRepository unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET
        public IActionResult Upsert(int? id)
        {
            ToDoVM toDoVM = new()
            {
                ToDo = new(),
                StatusList = _unitOfWork.ToDoStatus.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                //create ToD
                //ViewBag.CategoryList = CategoryList;
                //ViewData["CoverTypeList"] = CoverTypeList;
                return View(toDoVM);
            }
            else
            {
                toDoVM.ToDo = _unitOfWork.ToDo.GetFirstOrDefault(u => u.Id == id);
                return View(toDoVM);

                //update ToD
            }


        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ToDoVM obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                if (obj.ToDo.Id == 0)
                {
                    _unitOfWork.ToDo.Add(obj.ToDo);
                }
                else
                {
                    _unitOfWork.ToDo.Update(obj.ToDo);
                }
                _unitOfWork.Save();
                TempData["success"] = "Todo Task created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            Expression<Func<ToDoHistory, object>> todo = v => v.Task;
            Expression<Func<ToDoHistory, object>> ToDoStatus = v => v.Task.ToDoStatus;
            Expression<Func<ToDoHistory, object>>[] parameterArray = new Expression<Func<ToDoHistory, object>>[] { todo, ToDoStatus };

            var ToDoList = _unitOfWork.ToDoHistory.GetAll(u => u.IsDeleted != true, naProperties: parameterArray);
            if (ToDoList != null)
            {
                var result = ToDoList.Select(
                    x => new
                    {
                        Id=x.ToDoId,
                        Date = x.AssignedDate
                    }
                    ).ToList();

                return Json(new { data = result });
            }
            return Json(new { data = ToDoList });
        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.ToDo.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            //var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            //if (System.IO.File.Exists(oldImagePath))
            //{
            //    System.IO.File.Delete(oldImagePath);
            //}
            _unitOfWork.ToDo.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }


}
