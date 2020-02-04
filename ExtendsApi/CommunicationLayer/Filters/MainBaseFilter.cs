namespace ExtendsApi.CommunicationLayer.Filters
{
    public class MainBaseFilter<TKeyFilter> : ViewBaseFilter 
        where TKeyFilter : class
    {
        // PrimaryKey's
        public TKeyFilter Ids { get; set; }

        // Deleted
        public bool IsDeleted { get; set; }
    }
}
