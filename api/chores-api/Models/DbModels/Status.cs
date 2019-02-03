using System;
using System.Collections.Generic;

namespace ChoresApi.Models.DbModels
{
    public partial class Status
    {
        public Status()
        {
            UserAchievements = new HashSet<UserAchievements>();
            UserChores = new HashSet<UserChores>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }

        public ICollection<UserAchievements> UserAchievements { get; set; }
        public ICollection<UserChores> UserChores { get; set; }
    }
}
