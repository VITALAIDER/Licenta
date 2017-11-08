using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LC_02.Data.Entities
{
    public class History
    {
        [Key]
        public int HistoryId { get; set; }
        public int EventId { get; set; }
        public int IdUser { get; set; }

    }
}