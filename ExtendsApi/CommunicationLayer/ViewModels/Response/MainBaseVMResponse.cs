using System.ComponentModel.DataAnnotations;

namespace ExtendsApi.CommunicationLayer.ViewModels.Response
{
    public class MainBaseVMResponse<IdType> 
        where IdType : struct
    {
        [Display(Name = "Id")]
        public IdType Id { get; set; }
    }
}
