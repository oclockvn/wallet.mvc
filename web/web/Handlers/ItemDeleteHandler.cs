using MediatR;
using oclockvn.Repository;
using System.Threading.Tasks;
using web.Entities;
using web.ViewModels;

namespace web.Handlers
{
    public class ItemDeleteHandler : IAsyncRequestHandler<ItemDeleteViewModel, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Item> itemRepo;

        public ItemDeleteHandler(IUnitOfWork unit)
        {
            unitOfWork = unit;
            itemRepo = unit.Get<Item>();
        }

        public async Task<bool> Handle(ItemDeleteViewModel message)
        {
            itemRepo.Delete(x => message.Ids.Contains(x.Id));
            var result = await unitOfWork.CommitAsync();

            return result.Item1 > 0;
        }
    }
}