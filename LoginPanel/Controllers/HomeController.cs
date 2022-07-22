using Microsoft.AspNetCore.Mvc;
using LoginPanel.Models;
using System.Security.Cryptography;

namespace LoginPanel.Controllers
{
    public class HomeController : Controller
    {
        public UsersDBContext? db { get; set; } = new UsersDBContext();

        public string HashPassword(string? password)
        {
            byte[] salt;
            byte[] buffer2;

            if (password == null)
            {
                throw new ArgumentNullException("Password is null");
            }

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }

            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }

        public bool VerifyHashedPassword(string? hashedPassword, string? password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }


        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public async Task<ActionResult> Create(UsersModel smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (smodel.Email != null && smodel.Login != null && smodel.Password != null)
                    {
                        smodel.Password = HashPassword(smodel.Password);

                        await db!.Users.AddAsync(smodel);
                        await db!.SaveChangesAsync();

                        ViewData["Name"] = smodel.Login;
                        ViewData["Password"] = smodel.Password;
                        ViewData["Email"] = smodel.Email;

                        return View("Index");
                    }
                    else
                    {
                        if (smodel.Login != null && smodel.Password != null)
                        {
                            foreach (var item in db!.Users)
                            {
                                if (item.Login == smodel.Login && VerifyHashedPassword(item.Password, smodel.Password))
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
                        else
                        {
                            ViewData["ErrorMessage"] = "You did not complete all fields";
                            return View("ErrorView");
                        }
                    }
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
    }
}
