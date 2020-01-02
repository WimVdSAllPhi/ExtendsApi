using System;
using System.ComponentModel.DataAnnotations;

namespace ExtendsApi.DataLayer.Models
{
    public class BaseEntity<Type> : MainBaseEntity<Type>, IBaseEntity<Type> where Type : struct
    {
        // Created
        [MaxLength(30)]
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        // Updated
        [MaxLength(30)]
        public string ChangedBy { get; set; }
        public DateTime? ChangedDate { get; set; }
    }

    public interface IBaseEntity<Type> : IMainBaseEntity<Type> where Type : struct
    {
        string CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        string ChangedBy { get; set; }
        DateTime? ChangedDate { get; set; }
    }
}
