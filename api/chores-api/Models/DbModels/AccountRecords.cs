using System;
using System.Collections.Generic;

namespace ChoresApi.Models.DbModels
{
    public partial class AccountRecords
    {
        public int AccountRecordId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public decimal Balance { get; set; }

        public Users User { get; set; }
    }
}
