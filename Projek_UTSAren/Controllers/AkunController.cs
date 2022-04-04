using Projek_UTSAren.Data;
using Projek_UTSAren.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projek_UTSAren.Controllers
{
    public class AkunController : Controller
    {

        private readonly AppDbContext _context;

        public AkunController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Daftar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Daftar(User datanya)
        {

            var declareRole = _context.Tb_Roles.Where(
                x => x.Id == "1"
                ).FirstOrDefault();

            datanya.Roles = declareRole;


            _context.Tb_User.Add(datanya);
            _context.SaveChanges();

            return RedirectToAction("Masuk");
        }


        public IActionResult Masuk()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Masuk(User datanya)
        {

            var cariusername = _context.Tb_User.Where(
                                            bebas =>
                                            bebas.Username == datanya.Username
                                            ).FirstOrDefault();

            if (cariusername != null)
            {
                var cekpassword = _context.Tb_User.Where(
                                            bebas =>
                                            bebas.Username == datanya.Username
                                            &&
                                            bebas.Password == datanya.Password
                                            )
                                    .Include(bebas2 => bebas2.Roles)
                                    .FirstOrDefault();

                if (cekpassword != null)
                {
                  
                    var daftar = new List<Claim>
                    {
                        new Claim("Nama_Lengkap", cariusername.Nama_Lengkap),
                        new Claim("Role", cariusername.Roles.Id)
                    };

                    await HttpContext.SignInAsync(
                        new ClaimsPrincipal(
                            new ClaimsIdentity(daftar, "Cookie", "Nama_Lengkap", "Role")
                            )
                        );

                    if (cariusername.Roles.Id == "1")
                    {
                        return RedirectToAction(controllerName: "Home", actionName: "Index");
                    }

                    return RedirectToAction(controllerName: "Alumni", actionName: "Index");
                }

                ViewBag.pesan = "Password Anda Salah";

                return View(datanya);
            }

            ViewBag.pesan = "Username Anda Tidak Ada";

            return View(datanya);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}