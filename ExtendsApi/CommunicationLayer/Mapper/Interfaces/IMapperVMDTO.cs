using ExtendsApi.BusinessLayer.DTOs;
using ExtendsApi.BusinessLayer.Filters;
using ExtendsApi.CommunicationLayer.Filters;
using ExtendsApi.CommunicationLayer.ViewModels.Request;
using ExtendsApi.CommunicationLayer.ViewModels.Response;

namespace ExtendsApi.CommunicationLayer.Mapper.Interfaces
{
    public interface IMapperVMDTO<TIdType, TKeyFilter, TVMRequest, TVMResponse, TDTO, TVMFilter, TDTOFilter>
        where TIdType : struct
        where TKeyFilter : class
        where TVMRequest : MainBaseVMRequest<TIdType>
        where TVMResponse : MainBaseVMResponse<TIdType>
        where TDTO : BaseDTO<TIdType>
        where TDTOFilter : BaseDTOFilter<TKeyFilter>
        where TVMFilter : BaseFilter<TKeyFilter>
    {
        TDTOFilter MapFromVMtoDTO(TVMFilter filterVM);
        TDTO MapFromVMtoDTO(TVMRequest itemVM);
        TDTO MapFromVMtoDTO(TVMResponse itemVM);
    }
}
