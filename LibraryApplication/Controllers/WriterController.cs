using System;
using LibraryApplication.Data.Model;
using LibraryApplication.Data.UnitOfWork;
using System.Web.Mvc;

namespace LibraryApplication.Controllers
{
    public class WriterController : Controller
    {
        UnitOfWork _unitOfWork;

        public WriterController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var writers = _unitOfWork.GetRepository<Writer>().GetAll();

            return View(writers);
        }

        [HttpPost]
        public JsonResult AddJson(string wrtName)
        {
            Writer writer = new Writer() { WriterName= wrtName };
            var addedWriter = _unitOfWork.GetRepository<Writer>().Add(writer);
            _unitOfWork.SaveChanges();
            return Json(new
            {
                Result = new
                {
                    Id = addedWriter.Id,
                    Name = addedWriter.WriterName,
                },
                JsonRequestBehavior.AllowGet
            });
        }

        [HttpPost]
        public JsonResult UpdateJson(int wrtId, string wrtName)
        {
            var writer = _unitOfWork.GetRepository<Writer>().GetById(wrtId);
            writer.WriterName = wrtName;
            var status = _unitOfWork.SaveChanges();
            if (status > 0) return Json("1");
            else return Json("0");
        }

        [HttpPost]
        public JsonResult DeleteJson(int wrtId)
        {
            _unitOfWork.GetRepository<Writer>().Delete(wrtId);
            var status = _unitOfWork.SaveChanges();
            if (status > 0) return Json("1");
            else return Json("0");
        }
    }
}