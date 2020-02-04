using System.ComponentModel.DataAnnotations;

namespace ExtendsApi.CommunicationLayer.ViewModels.Request
{
    public class MainBaseVMRequest<IdType> 
        where IdType : struct
    {
        [Display(Name = "Id")]
        public IdType Id { get; set; }
    }
}
