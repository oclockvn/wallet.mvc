﻿using MediatR;
using System.Collections.Generic;

namespace web.ViewModels
{
    public class ItemDeleteViewModel : IRequest<bool>
    {
        public List<int> Ids { get; set; } = new List<int>();
    }
}