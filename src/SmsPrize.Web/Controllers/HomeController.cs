using System;
using Microsoft.AspNet.Mvc;
using SmsPrize.Web.Models;
using SmsPrize.Web.Services;

namespace SmsPrize.Web
{
    public class HomeController : Controller
    {
        private SmsService SmsService { get; set; }

        public HomeController(SmsService smsService)
        {
            SmsService = smsService;
        }

        public IActionResult Index()
        {
            var model = SmsService.RandomCube();
            return View(model);
        }
    }
}
