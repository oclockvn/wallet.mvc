using MediatR;
using oclockvn.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using web.Entities;
using web.ViewModels;

namespace web.Handlers
{
    public class WalletIndexHandler : IRequestHandler<WalletIndexViewModel, List<ItemIndexViewModel>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Wallet> walletRepo;
        private readonly IRepository<Item> itemRepo;

        public WalletIndexHandler(IUnitOfWork unit)
        {
            unitOfWork = unit;
            walletRepo = unit.Get<Wallet>();
            itemRepo = unit.Get<Item>();
        }

        public List<ItemIndexViewModel> Handle(WalletIndexViewModel message)
        {
            var userId = message.UserId;
            // var wallet = walletRepo.Get(x => x.UserId == userId && x.Items.Any(i => DbFunctions.DiffMonths(DateTime.Now, i.Time) == 0), x => x.Items);
            var items = (from i in itemRepo.All.Where(x => DbFunctions.DiffMonths(DateTime.Now, x.Time) == 0)
                        join w in walletRepo.All.Where(x => x.UserId == x.UserId) on i.WalletId equals w.Id
                        orderby i.Time descending
                        select i).ToList();


            if (items == null)
                return new List<ItemIndexViewModel>();

            return MapperConfig.Factory.Map<List<Item>, List<ItemIndexViewModel>>(items);
        }
    }
}