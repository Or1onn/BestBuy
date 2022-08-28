using Microsoft.AspNetCore.Mvc;
using LoginPanel.Models;
using System.IdentityModel.Tokens.Jwt;
using LoginPanel.Services;
using BestBuy.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LoginPanel.Controllers
{
    public class LoginController : Controller
    {
        public UsersDBContext? db { get; set; } = new UsersDBContext();
        public PasswordHasher? hasher { get; set; } = new PasswordHasher();
        public EmailSender sender { get; set; } = new EmailSender();
        public static string? UserLogin { get; set; }


        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Email Authentication Email
        /// </summary>
        /// <remarks>
        /// Note: to create account you need to enter Authentication code which you can receive from method SendAuthenticationEmail
        /// 
        /// Sample request:
        ///
        ///     POST /EmailAuthentication
        ///     {
        ///        "Login": "Jone",
        ///     }
        ///
        /// </remarks>
        [HttpPost("/Login/SendAuthenticationEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SendAuthenticationEmail(string Login)
        {
            if (Login != null)
            {
                foreach (var item in db!.Users)
                {
                    if (item.Login == Login)
                    {
                        UserLogin = Login;
                        await sender.Send(item.Email);
                    }
                }
                return View("EmailAuthentication");
            }
            else
            {
                ViewData["ErrorMessage"] = "Enter your login!!";
                return View("ErrorView");
            }
        }

        public ActionResult ShowEnterEmail()
        {
            return View("EnterEmail");
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public async Task<ActionResult> Create(UsersModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await sender.Send(model.Email);

                    TempData["Name"] = model.Login;
                    TempData["Password"] = model.Password;
                    TempData["Email"] = model.Email;

                    return View("Authentication");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Login in Account
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Login
        ///     {
        ///        "Login": "James",
        ///        "Password": "qwerty123",
        ///     }
        ///
        /// </remarks>
        [HttpPost("/Login/Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Login(UsersModel model)
        {
            foreach (var item in db!.Users)
            {
                if (item.Login == model.Login && hasher!.VerifyHashedPassword(item.Password, model.Password))
                {
                    ViewData["Name"] = item.Login;
                    ViewData["Password"] = item.Password;
                    ViewData["Email"] = item.Email;
                    return View("Index");
                }
            }
            ViewData["ErrorMessage"] = "Not found your account";
            return View("ErrorView");
        }


        /// <summary>
        /// Create New Account
        /// </summary>
        /// <remarks>
        /// Note: to create account you need to enter Authentication code which you can receive from method SendAuthenticationEmail
        /// 
        /// Sample request:
        ///
        ///     POST /CreateAccount
        ///     {
        ///        "Code": "B9A1I1",
        ///     }
        ///
        /// </remarks>
        [HttpPost("/Login/CreateAccount")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateAccount(string code)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(JWTModel.VALUE);

            if (token.Claims.First().Value == code)
            {
                UsersModel model = new UsersModel();

                model.Login = TempData["Name"]?.ToString();
                model.Email = TempData["Email"]?.ToString();
                model.Password = hasher!.HashPassword(TempData["Password"]?.ToString());

                await db!.Users.AddAsync(model);
                await db!.SaveChangesAsync();


                ViewData["Name"] = model.Login;
                ViewData["Password"] = model.Password;
                ViewData["Email"] = model.Email;

                return View("Index");
            }
            else
            {
                ViewData["ErrorMessage"] = "Your code is invalid or expired!";
                return View("ErrorView");
            }
        }

        /// <summary>
        /// Authentication
        /// </summary>
        /// <remarks>
        /// Note: to create account you need to enter Authentication code which you can receive from method SendAuthenticationEmail
        /// 
        /// Sample request:
        ///
        ///     POST /Authentication
        ///     {
        ///        "Code": "B9A1I1",
        ///     }
        ///
        /// </remarks>
        [HttpPost("/Login/Authentication")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Authentication(string code)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(JWTModel.VALUE);

            if (token.Claims.First().Value == code)
            {
                UsersModel model = new UsersModel();

                model.Login = TempData["Name"]?.ToString();
                model.Email = TempData["Email"]?.ToString();
                model.Password = hasher!.HashPassword(TempData["Password"]?.ToString());

                await db!.Users.AddAsync(model);
                await db!.SaveChangesAsync();

                ViewData["Name"] = model.Login;
                ViewData["Password"] = model.Password;
                ViewData["Email"] = model.Email;

                return View("Index");
            }
            else
            {
                ViewData["ErrorMessage"] = "Your code is invalid or expired!";
                return View("ErrorView");
            }
        }



        /// <summary>
        /// Email Authentication
        /// </summary>
        /// <remarks>
        /// Note: to create account you need to enter Authentication code which you can receive from method SendAuthenticationEmail
        /// 
        /// Sample request:
        ///
        ///     POST /EmailAuthentication
        ///     {
        ///        "Code": "B9A1I1",
        ///     }
        ///
        /// </remarks>
        [HttpPost("/Login/EmailAuthentication")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult EmailAuthentication(string code)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(JWTModel.VALUE);

            if (token.Claims.First().Value == code)
            {

                return View("CreateNewPassword");
            }
            else
            {
                ViewData["ErrorMessage"] = "Your code is invalid or expired!";
                return View("ErrorView");
            }
        }

        /// <summary>
        /// Creating New Password
        /// </summary>
        /// <remarks>
        /// Note: To Create new password you need to receive Authentication from you gmail
        /// </remarks>
        [HttpPost("/Login/CreateNewPassword")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateNewPassword(string Password)
        {
            if (Password != null)
            {
                foreach (var item in db!.Users)
                {
                    if (item.Login == UserLogin)
                    {
                        item.Password = hasher!.HashPassword(Password);

                        ViewData["Name"] = item.Login;
                        ViewData["Password"] = item.Password;
                        ViewData["Email"] = item.Email;
                    }
                }
                await db!.SaveChangesAsync();

                return View("Index");
            }
            else
            {
                ViewData["ErrorMessage"] = "Your code is invalid or expired!";
                return View("ErrorView");
            }
        }
    }
}
