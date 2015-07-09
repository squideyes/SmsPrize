using Microsoft.AspNet.Mvc;
using SmsPrize.Web.Services;

namespace SmsPrize.Web
{
    public class TriggerController : Controller
    {
        private SmsService SmsService { get; set; }

        public TriggerController(SmsService smsService)
        {
            SmsService = smsService;
        }

        [Route("api/trigger")]
        [HttpPost]
        public IActionResult Trigger()
        {
            try
            {
                var result = SmsService.RandomCube();

                return Json(result);
            }
            catch
            {
                return Content("error");
            }
        }
    }
}
