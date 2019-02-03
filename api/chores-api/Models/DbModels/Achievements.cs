using System;
using System.Collections.Generic;

namespace ChoresApi.Models.DbModels
{
    public partial class Achievements
    {
        public Achievements()
        {
            UserAchievements = new HashSet<UserAchievements>();
        }

        public int AchievementId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ChoreId { get; set; }
        public decimal? ChoreRaise { get; set; }
        public decimal? OneTimeBonusPay { get; set; }

        public ICollection<UserAchievements> UserAchievements { get; set; }
    }
}
