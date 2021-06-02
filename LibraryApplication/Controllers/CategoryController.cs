using System;
using LibraryApplication.Data.Model;
using LibraryApplication.Data.UnitOfWork;
using System.Web.Mvc;

namespace LibraryApplication.Controllers
{
    public class CategoryController : Controller
    {
        UnitOfWork _unitOfWork;

        public CategoryController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var categories = _unitOfWork.GetRepository<Category>().GetAll();
            return View(categories);
        }

        [HttpPost]
        public JsonResult AddJson(string ctgName)
        {
            Category category = new Category { CategoryName = ctgName };
            var addedCategory = _unitOfWork.GetRepository<Category>().Add(category);
            _unitOfWork.SaveChanges();
            return Json(new
            {
                Result = new
                {
                    Id = addedCategory.Id,
                    Name = addedCategory.CategoryName,
                },
                JsonRequestBehavior.AllowGet
            });
        }

        [HttpPost]
        public JsonResult UpdateJson(int ctgId, string ctgName)
        {
            var category = _unitOfWork.GetRepository<Category>().GetById(ctgId);
            category.CategoryName = ctgName;
            var status = _unitOfWork.SaveChanges();
            if (status > 0) return Json("1");
            else return Json("0");
        }

        [HttpPost]
        public JsonResult DeleteJson(int ctgId)
        {
            Console.WriteLine(ctgId);
            _unitOfWork.GetRepository<Category>().Delete(ctgId);
            var status = _unitOfWork.SaveChanges();
            if (status > 0) return Json("1");
            else return Json("0");
        }
    }
}