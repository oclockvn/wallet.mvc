using MediatR;
using oclockvn.Repository;
using System.Data.SqlClient;
using System.Threading.Tasks;
using web.ViewModels;

namespace web.Handlers
{
    public class ItemUndoneHandler : IAsyncRequestHandler<ItemUndoneViewModel, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public ItemUndoneHandler(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }

        public async Task<bool> Handle(ItemUndoneViewModel message)
        {
            var result = await unitOfWork.ExecuteSqlAsync("update Items set Done = 0 where Id = @id", new SqlParameter("@id", message.Id));
            return result > 0;
        }
    }
}