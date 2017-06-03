using MediatR;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using web.MapperExtensions;
using web.ViewModels;

namespace web.Controllers
{   
    [RoutePrefix("wallet")]
    public class WalletController : BaseController
    {
        private readonly IMediator mediator;

        public WalletController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("info")]
        public async Task<ActionResult> WalletItems()
        {
            var items = await mediator.Send(new WalletIndexViewModel { Time = DateTime.Now, UserId = User.Identity.GetUserId<int>() });
            var today = DateTime.Now.ToString("MM/dd/yyyy");

            return Json(new { today, items }, JsonRequestBehavior.AllowGet);
        }

        [Route("add")]
        [HttpPost]
        public async Task<ActionResult> CreateItem(ItemCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return Json(new { code = 0, data = ErrorModels }, JsonRequestBehavior.DenyGet);

            var tuple = await mediator.Send(model);

            if (tuple.Item1 == null || tuple.Item1.Id == 0)
                return Json(new { code = 1, msg = tuple.Item2 }, JsonRequestBehavior.DenyGet);

            return Json(new { code = 1, data = tuple.Item1.ToItemIndex() }, JsonRequestBehavior.DenyGet);
        }
    }
}