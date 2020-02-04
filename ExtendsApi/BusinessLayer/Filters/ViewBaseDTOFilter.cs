using ExtendsApi.Models;
using System.Collections.Generic;

namespace ExtendsApi.BusinessLayer.Filters
{
    public class ViewBaseDTOFilter
    {
        public string ContainsInAllFields { get; set; }
        public Dictionary<string, string> ContainsSomeFields { get; set; }

        public OrderExtention OrderExtention { get; set; }
    }
}
