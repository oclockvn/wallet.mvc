using MediatR;

namespace web.ViewModels
{
    public class ItemDeleteViewModel : IRequest<bool>
    {
        public int Id { get; set; }
    }
}