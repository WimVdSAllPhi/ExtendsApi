using System.Collections.Generic;

namespace ExtendsApi.Models.ViewModels
{
    public class ViewBaseFilter
    {
        public string ContainsInAllFields { get; set; }
        public Dictionary<string, string> ContainsSomeFields { get; set; }

        public OrderExtention OrderExtention { get; set; }
    }
}
