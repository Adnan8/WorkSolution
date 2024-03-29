﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Linq.Expressions;
using WS.Business.Base;
using WS.Domain.Model;
using WS.Domain.ViewModels;
using WS.Utility;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin+"," + SD.Role_Employee)]
    public class ToDOController : Controller
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;


        public ToDOController(IUnitOfWorkRepository unitOfWork, IWebHostEnvironment hostEnvironment)
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
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\ToDO");
                    var extension = Path.GetExtension(file.FileName);

                    //if (obj.ToDo.ImageUrl != null)
                    //{
                    //    var oldImagePath = Path.Combine(wwwRootPath, obj.ToDo.ImageUrl.TrimStart('\\'));
                    //    if (System.IO.File.Exists(oldImagePath))
                    //    {
                    //        System.IO.File.Delete(oldImagePath);
                    //    }
                    //}

                    //using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    //{
                    //    file.CopyTo(fileStreams);
                    //}
                    //obj.ToDo.ImageUrl = @"\images\Todo\" + fileName + extension;

                }
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
            Expression<Func<ToDoHistory, object>> ToDoStatus = v => v.Task.ToDoStatus;
            Expression<Func<ToDoHistory, object>>[] parameterArray = new Expression<Func<ToDoHistory, object>>[] { ToDoStatus };
            var ToDoList = _unitOfWork.ToDoHistory.GetAll(u => u.IsDeleted != true, naProperties: parameterArray);
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
