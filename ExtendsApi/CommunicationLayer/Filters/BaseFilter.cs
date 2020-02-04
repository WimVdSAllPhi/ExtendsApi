using ExtendsApi.Models;

namespace ExtendsApi.CommunicationLayer.Filters
{
    public class BaseFilter<TKeyFilter> : MainBaseFilter<TKeyFilter> 
        where TKeyFilter : class
    {
        // Created
        public StringFilter CreatedBy { get; set; }
        public DateTimeNullableFilter CreatedDate { get; set; }

        // Updated
        public StringFilter ChangedBy { get; set; }
        public DateTimeNullableFilter ChangedDate { get; set; }
    }
}
