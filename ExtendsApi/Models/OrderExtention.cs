namespace ExtendsApi.Models
{
    public class OrderExtention
    {
        public OrderBy OrderBy { get; set; }
        public string Property { get; set; }
    }

    public enum OrderBy
    {
        Ascending,
        Descending
    }
}
