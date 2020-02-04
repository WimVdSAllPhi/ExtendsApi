using ExtendsApi.Models;
using System.Collections.Generic;

namespace ExtendsApi.CommunicationLayer.Filters
{
    public class ViewBaseFilter
    {
        public string ContainsInAllFields { get; set; }
        public Dictionary<string, string> ContainsSomeFields { get; set; }

        public OrderExtention OrderExtention { get; set; }
    }
}
