using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace LogginMiddleware.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Nome, string Senha)
        {
            if (Nome == null && Senha == null)
                return View("Index");

            HttpContext.Session.SetString("Nome", Nome);
            return View("Welcome");
        }
    }
}
