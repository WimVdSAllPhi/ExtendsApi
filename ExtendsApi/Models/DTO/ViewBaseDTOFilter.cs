﻿using System.Collections.Generic;

namespace ExtendsApi.Models.DTO
{
    public class ViewBaseDTOFilter
    {
        public string ContainsInAllFields { get; set; }
        public Dictionary<string, string> ContainsSomeFields { get; set; }

        public OrderExtention OrderExtention { get; set; }
    }
}