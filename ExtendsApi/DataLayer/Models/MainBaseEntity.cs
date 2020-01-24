using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExtendsApi.DataLayer.Models
{
    public class MainBaseEntity<Type> : IMainBaseEntity<Type> where Type : struct
    {
        [Key]
        public Type Id { get; set; }

        // Deleted
        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;
    }


    public interface IMainBaseEntity<Type> where Type : struct
    {
        Type Id { get; set; }
        bool IsDeleted { get; set; }
    }
}
