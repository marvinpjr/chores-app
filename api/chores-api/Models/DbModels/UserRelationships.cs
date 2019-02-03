using System;
using System.Collections.Generic;

namespace ChoresApi.Models.DbModels
{
    public partial class UserRelationships
    {
        public int UserRelationshipId { get; set; }
        public int FirstUserId { get; set; }
        public int RelationshipId { get; set; }
        public int SecondUserId { get; set; }

        public Users FirstUser { get; set; }
        public Relationships Relationship { get; set; }
        public Users SecondUser { get; set; }
    }
}
