using MediatR;
using System;
using System.Collections.Generic;

namespace web.ViewModels
{
    public class WalletIndexViewModel : IRequest<List<ItemIndexViewModel>>
    {
        public DateTime Time { get; set; }
        public int UserId { get; set; }
    }
}