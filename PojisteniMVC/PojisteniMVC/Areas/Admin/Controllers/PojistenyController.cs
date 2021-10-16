using Microsoft.AspNetCore.Mvc;
using PojisteniMVC.DataAccess.Repository.IRepository;
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

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll() //vrátí všechny pojištěné v JSON formátu
        {
            var allObj = _unitOfWork.Pojisteny.GetAll();
            return Json(new { data = allObj });
        }
        #endregion
    }
}
