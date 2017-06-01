using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models;

namespace web.Entities
{
    public class Wallet : TEntity
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}