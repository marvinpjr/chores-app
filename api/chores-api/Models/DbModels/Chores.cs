using System;
using System.Collections.Generic;

namespace ChoresApi.Models.DbModels
{
    public partial class Chores
    {
        public Chores()
        {
            UserChores = new HashSet<UserChores>();
        }

        public int ChoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Pay { get; set; }

        public ICollection<UserChores> UserChores { get; set; }
    }
}
