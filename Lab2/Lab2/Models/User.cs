using System;
using System.Collections.Generic;

#nullable disable

namespace Lab2.Models
{
    public partial class User
    {
        public User()
        {
            Subscriptions = new HashSet<Subscription>();
        }

        public int UserId { get; set; }
        public string Fullname { get; set; }
        public int? Age { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
