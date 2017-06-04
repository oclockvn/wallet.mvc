using MediatR;

namespace web.ViewModels
{
    public class ItemUndoneViewModel : IRequest<bool>
    {
        public int Id { get; set; }
    }
}