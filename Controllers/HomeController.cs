using Microsoft.AspNetCore.Mvc;
using LoginPanel.Models;
using System.IdentityModel.Tokens.Jwt;
using LoginPanel.Services;

namespace LoginPanel.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("HomeWindow");
        }
    }
}
