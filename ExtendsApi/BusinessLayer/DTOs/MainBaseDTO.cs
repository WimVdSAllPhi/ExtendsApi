namespace ExtendsApi.BusinessLayer.DTOs
{
    public class MainBaseDTO<IdType>
        where IdType : struct
    {
        // PrimaryKey
        public IdType Id { get; set; }

        // Deleted
        public bool IsDeleted { get; set; } = false;
    }
}
