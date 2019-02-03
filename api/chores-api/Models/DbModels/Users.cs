using System;
using System.Collections.Generic;

namespace ChoresApi.Models.DbModels
{
    public partial class Users
    {
        public Users()
        {
            AccountRecords = new HashSet<AccountRecords>();
            UserAchievements = new HashSet<UserAchievements>();
            UserChores = new HashSet<UserChores>();
            UserRelationshipsFirstUser = new HashSet<UserRelationships>();
            UserRelationshipsSecondUser = new HashSet<UserRelationships>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<AccountRecords> AccountRecords { get; set; }
        public ICollection<UserAchievements> UserAchievements { get; set; }
        public ICollection<UserChores> UserChores { get; set; }
        public ICollection<UserRelationships> UserRelationshipsFirstUser { get; set; }
        public ICollection<UserRelationships> UserRelationshipsSecondUser { get; set; }
    }
}
