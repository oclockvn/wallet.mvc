using MediatR;
using Microsoft.AspNet.Identity;
using oclockvn.Repository;
using System;
using System.Web;
using web.Entities;
using web.MapperExtensions;
using web.ViewModels;

namespace web.Handlers
{
    public class ItemCreateHandler : IRequestHandler<ItemCreateViewModel, Tuple<Item, string>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Wallet> walletRepo;
        private readonly IRepository<Item> itemRepo;

        public ItemCreateHandler(IUnitOfWork unit)
        {
            unitOfWork = unit;
            walletRepo = unit.Get<Wallet>();
            itemRepo = unit.Get<Item>();
        }

        public Tuple<Item, string> Handle(ItemCreateViewModel message)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId<int>();
            var wallet = walletRepo.Get(x => x.UserId == userId);
            var item = message.ToItem();
            item.WalletId = wallet.Id;

            itemRepo.Create(item);
            var result = unitOfWork.Commit();

            return new Tuple<Item, string>(item, string.Empty);
        }
    }
}