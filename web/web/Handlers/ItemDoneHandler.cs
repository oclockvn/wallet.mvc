using MediatR;
using oclockvn.Repository;
using System.Threading.Tasks;
using web.Entities;
using web.ViewModels;

namespace web.Handlers
{
    public class ItemDoneHandler : IAsyncRequestHandler<ItemDoneViewModel, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Item> itemRepo;

        public ItemDoneHandler(IUnitOfWork unit)
        {
            unitOfWork = unit;
            itemRepo = unit.Get<Item>();
        }

        public async Task<bool> Handle(ItemDoneViewModel message)
        {
            var ids = string.Join(",", message.Ids);
            var result = await unitOfWork.ExecuteSqlAsync($"update Items set Done = 1 where Id in ({ids})");
            return result > 0;
        }
    }
}