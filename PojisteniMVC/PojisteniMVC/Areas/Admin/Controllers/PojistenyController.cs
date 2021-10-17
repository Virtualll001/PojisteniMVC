using Microsoft.AspNetCore.Mvc;
using PojisteniMVC.DataAccess.Repository.IRepository;
using PojisteniMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PojisteniMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PojistenyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PojistenyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id) //id jen v případě update/edit
        {
            Pojisteny pojisteny = new Pojisteny();
            if(id == null) //jde o create
            {
                return View(pojisteny);
            }
            //jde o update/edit
            pojisteny = _unitOfWork.Pojisteny.Get(id.GetValueOrDefault());
            if (pojisteny == null)
            {
                return NotFound();
            }
            return View(pojisteny);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Pojisteny pojisteny)
        {
            if (ModelState.IsValid)
            {
                if (pojisteny.PojistenyId == 0)
                {
                    _unitOfWork.Pojisteny.Add(pojisteny);
                }
                else
                {
                    _unitOfWork.Pojisteny.Update(pojisteny);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index)); //nepoužívat "magic string"
            }
            return View(pojisteny);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll() //vrátí všechny pojištěné v JSON formátu
        {
            var allObj = _unitOfWork.Pojisteny.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Pojisteny.Get(id);
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Chyba při mazání" });
            }
            _unitOfWork.Pojisteny.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Odstranění proběhlo úspěšně" });
        }

        #endregion
    }
}
