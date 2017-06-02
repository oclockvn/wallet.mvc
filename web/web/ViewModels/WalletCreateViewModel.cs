using MediatR;

namespace web.ViewModels
{
    public class WalletCreateViewModel : IRequest<bool>
    {
        public int UserId { get; set; }
        public string Username { get; set; }
    }
}