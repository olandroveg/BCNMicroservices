﻿using System;
namespace UDRF.Dto.FilterDto
{
    public class BaseFilter
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public Guid Userid { get; set; }
        public Guid RefenceId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
