using System;

namespace web.ViewModels
{
    public class ItemIndexViewModel
    {
        public bool @checked { get; set; }
        public DateTime time { get; set; }
        public string note { get; set; }
        public decimal money { get; set; }
        public bool done { get; set; }
        public bool active { get; set; }
    }
}