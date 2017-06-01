using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Entities
{
    public class Item : TEntity
    {
        public bool Checked { get; set; }
        public DateTime Time { get; set; }
        public string Note { get; set; }
        public decimal Money { get; set; }
        public bool Done { get; set; }
        public bool Active { get; set; }

        [ForeignKey(nameof(Wallet))]
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
    }
}