using System;
using System.Collections.Generic;

namespace ChoresApi.Models.DbModels
{
    public partial class UserChores
    {
        public int UserChoreId { get; set; }
        public int UserId { get; set; }
        public int ChoreId { get; set; }
        public int StatusId { get; set; }

        public Chores Chore { get; set; }
        public Status Status { get; set; }
        public Users User { get; set; }
    }
}
