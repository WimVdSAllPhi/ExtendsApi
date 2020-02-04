namespace ExtendsApi.BusinessLayer.Filters
{
    // (IntFilter, StringFilter, DateTimeNullableFilter, DecimalFilter, GuidFilter)
    public class MainBaseDTOFilter<TKeyFilter> : ViewBaseDTOFilter 
        where TKeyFilter : class
    {
        // PrimaryKey's
        public TKeyFilter Ids { get; set; }

        // Deleted
        public bool IsDeleted { get; set; }
    }
}
