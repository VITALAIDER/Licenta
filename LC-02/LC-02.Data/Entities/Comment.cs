using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_02.Data.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int EventId { get; set; }
        public string CommentContent { get; set; }
    }
}
