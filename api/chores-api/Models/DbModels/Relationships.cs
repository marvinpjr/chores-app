using System;
using System.Collections.Generic;

namespace ChoresApi.Models.DbModels
{
    public partial class Relationships
    {
        public Relationships()
        {
            UserRelationships = new HashSet<UserRelationships>();
        }

        public int RelationshipId { get; set; }
        public string Name { get; set; }

        public ICollection<UserRelationships> UserRelationships { get; set; }
    }
}
