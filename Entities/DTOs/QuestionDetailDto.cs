﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class QuestionDetailDto
    {
        public int QuestionId { get; set; }
        public string QuestionDescription { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public List<QuestionImage> QuestionImage { get; set; }

    }
}
