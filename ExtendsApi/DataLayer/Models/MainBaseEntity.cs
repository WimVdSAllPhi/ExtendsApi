using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExtendsApi.DataLayer.Models
{
    public class MainBaseEntity<IdType> 
        where IdType : struct
    {
        [Key]
        public IdType Id { get; set; }

        // Deleted
        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }
}
