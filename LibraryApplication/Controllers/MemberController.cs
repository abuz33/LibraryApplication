using System;
using LibraryApplication.Data.Model;
using LibraryApplication.Data.UnitOfWork;
using System.Web.Mvc;

namespace LibraryApplication.Controllers
{
    public class MemberController : Controller
    {
        UnitOfWork _unitOfWork;

        public MemberController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var members = _unitOfWork.GetRepository<Member>().GetAll();

            return View(members);
        }

        public ActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddMemberJson(string name, string lastname, string identityNumber, string phone)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(lastname))
            {
                Member member = new Member();
                member.MemberName = name;
                member.MemberLastname = lastname;
                member.IdentityNumber = identityNumber;
                member.PhoneNumber = phone;
                member.Punishment = 0;
                member.RegistirationDate = DateTime.Now;
                _unitOfWork.GetRepository<Member>().Add(member);
                var status = _unitOfWork.SaveChanges();
                if (status > 1) return Json('1');
                else return Json("0");
            }
            else
            {
                return Json("cannot be empty");
            }
        }

        [HttpPost]
        public JsonResult DeleteMemberJson(int memberId)
        {
            _unitOfWork.GetRepository<Member>().Delete(memberId);
            var status = _unitOfWork.SaveChanges();
            //return Json(status);
            if (status > 0) return Json("1");
            else return Json("0");
        }

        public ActionResult Update(int memberId)
        {
            var member = _unitOfWork.GetRepository<Member>().GetById(memberId);
            return View(member);
        }

        [HttpPost]
        public JsonResult UpdateMemberJson(int memberId, string name, string lastname, string identityNumber, string phone)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(lastname))
            {
                var member = _unitOfWork.GetRepository<Member>().GetById(memberId);
                member.MemberName = name;
                member.MemberLastname = lastname;
                member.IdentityNumber = identityNumber;
                member.PhoneNumber = phone;
                member.Punishment = 0;
                _unitOfWork.GetRepository<Member>().Update(member);
                var status = _unitOfWork.SaveChanges();
                if (status > 1) return Json('1');
                else return Json("0");
            }
            else
            {
                return Json("cannot be empty");
            }
        }
    }
}