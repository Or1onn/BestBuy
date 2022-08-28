using Microsoft.AspNetCore.Mvc;
using System;
using LoginPanel.Models;
using BestBuy.Models;
using System.IdentityModel.Tokens.Jwt;
using LoginPanel.Services;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Extensions.Hosting;
using System.Web;

namespace LoginPanel.Controllers
{
    public class HomeController : Controller
    {
        IWebHostEnvironment? _appEnvironment;

        public HomeController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("HomeWindow");
        }


        public ActionResult ProductAddingPage()
        {
            return View("CreateProduct");
        }
        [HttpPost("/Home/SaveUploadedFile")]
        public async Task<IActionResult> SaveUploadedFile([FromForm] IList<IFormFile> files)
        {
            string absolutepath = _appEnvironment.WebRootPath;
            Path.Combine(absolutepath, "Files");
            foreach (var file in files)
            {
                try
                {
                    var uploads = Path.Combine(absolutepath, file.FileName);
                    using (var fileStream = new FileStream(uploads, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return RedirectToAction("ProductAddingPage");

        }
    }
}
