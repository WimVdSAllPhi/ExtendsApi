using System;
using System.ComponentModel.DataAnnotations;

namespace ExtendsApi.DataLayer.Models
{
    public class BaseEntity<IdType> : MainBaseEntity<IdType>
        where IdType : struct
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
}
