using System;
using System.ComponentModel.DataAnnotations;

namespace ExtendsApi.BusinessLayer.DTOs
{
    public class BaseDTO<IdType> : MainBaseDTO<IdType>
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
