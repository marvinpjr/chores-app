using System;
using System.Collections.Generic;

namespace ChoresApi.Models.DbModels
{
    public partial class UserAchievements
    {
        public int UserAchievementId { get; set; }
        public int UserId { get; set; }
        public int AchievementId { get; set; }
        public int StatusId { get; set; }
        public int Progress { get; set; }
        public int Finish { get; set; }

        public Achievements Achievement { get; set; }
        public Status Status { get; set; }
        public Users User { get; set; }
    }
}
