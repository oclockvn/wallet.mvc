using MediatR;
using System;
using web.Entities;

namespace web.ViewModels
{
    public class ItemCreateViewModel : IRequest<Tuple<Item, string>>
    {
        public string Note { get; set; }
        public decimal Money { get; set; }
    }
}