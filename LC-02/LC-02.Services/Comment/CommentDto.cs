﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_02.Services.Comment
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public int EventId { get; set; }
        public int Content { get; set; }
    }
}
