using MediatR;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
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

        [Route("item/add")]
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

        [Route("item/remove")]
        public async Task<ActionResult> RemoveItem(List<int> itemIds)
        {
            var success = await mediator.Send(new ItemDeleteViewModel { Ids = itemIds });
            return Json(success, JsonRequestBehavior.DenyGet);
        }

        [Route("item/done")]
        public async Task<ActionResult> DoneItem(List<int> itemIds)
        {
            var success = await mediator.Send(new ItemDoneViewModel { Ids = itemIds });
            return Json(success, JsonRequestBehavior.DenyGet);
        }

        [Route("item/undone")]
        public async Task<ActionResult> UndoneItem(int itemId)
        {
            var success = await mediator.Send(new ItemUndoneViewModel { Id = itemId });
            return Json(success, JsonRequestBehavior.DenyGet);
        }
    }
}