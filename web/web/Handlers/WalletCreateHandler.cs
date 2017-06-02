using MediatR;
using oclockvn.Repository;
using System;
using System.Threading.Tasks;
using web.Entities;
using web.ViewModels;

namespace web.Handlers
{
    public class WalletCreateHandler : IAsyncRequestHandler<WalletCreateViewModel, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Wallet> walletRepo;

        public WalletCreateHandler(IUnitOfWork unit)
        {
            unitOfWork = unit;
            walletRepo = unit.Get<Wallet>();
        }

        public async Task<bool> Handle(WalletCreateViewModel message)
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