using MediatR;
using oclockvn.Repository;
using System;
using web.Entities;
using web.ViewModels;

namespace web.Handlers
{
    public class WalletCreateHandler : IRequestHandler<WalletCreateViewModel, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Wallet> walletRepo;

        public WalletCreateHandler(IUnitOfWork unit)
        {
            unitOfWork = unit;
            walletRepo = unit.Get<Wallet>();
        }

        public bool Handle(WalletCreateViewModel message)
        {
            var wallet = new Wallet
            {
                CreatedDate = DateTime.Now,
                Name = $"{message.Username}'sWallet",
                UserId = message.UserId
            };

            walletRepo.Create(wallet);
            var result = unitOfWork.Commit();

            return result.Item1 > 0;
        }
    }
}