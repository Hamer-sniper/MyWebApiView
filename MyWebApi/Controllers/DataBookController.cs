using Microsoft.AspNetCore.Mvc;
using MyWebApiView.Models;
using MyWebApiView.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MyWebApiView.Controllers
{
    public class DataBookController : Controller
    {
        private readonly IDataBookData dataBookData;
        public DataBookController(IDataBookData dBData)
        {
            dataBookData = dBData;
        }

        public void AddTokenToHeader()
        {
            var token = HttpContext.Request.Cookies[".AspNetCore.Application.Id"];
            if (!string.IsNullOrEmpty(token))
                dataBookData.AddTokenToClient(token);
        }

        [HttpGet]
        //[AllowAnonymous]
        public IActionResult Index()
        {
            AddTokenToHeader();

            ViewBag.DataBook = dataBookData.GetAllDatabooks();
            return View();
        }

        [HttpGet]
        //[Authorize]
        public IActionResult GetDataBook(int dataBookId)
        {
            AddTokenToHeader();

            return View(dataBookData.ReadDataBook(dataBookId));
        }

        [HttpGet]
        //[Authorize]
        public IActionResult AddDataBook()
        {
            AddTokenToHeader();

            return View();
        }

        [HttpPost]
        //[Authorize]
        public IActionResult AddDataFromField(DataBook dataBook)
        {
            AddTokenToHeader();

            dataBookData.CreateDataBook(dataBook);
            return Redirect("~/");
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public IActionResult EditDataBook(int dataBookId)
        {
            AddTokenToHeader();

            return View(dataBookData.ReadDataBook(dataBookId));
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public IActionResult EditDataFromField(DataBook dataBook)
        {
            AddTokenToHeader();

            dataBookData.UpdateDataBook(dataBook);
            return Redirect("~/");
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public IActionResult DeleteDataBook(int dataBookId)
        {
            AddTokenToHeader();

            return View(dataBookData.ReadDataBook(dataBookId));
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public IActionResult DeleteDataFromField(DataBook dataBook)
        {
            AddTokenToHeader();

            dataBookData.DeleteDataBook(dataBook);
            return Redirect("~/");
        }
    }
}