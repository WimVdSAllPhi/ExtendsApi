using ExtendsApi.BusinessLayer.DTOs;
using ExtendsApi.CommunicationLayer.ViewModels.Response;
using ExtendsApi.Models;
using System.Collections.Generic;

namespace ExtendsApi.CommunicationLayer.Mapper.Interfaces
{
    public interface IMapperDTOVM<TIdType, TVMResponse, TDTO>
        where TIdType : struct 
        where TVMResponse : MainBaseVMResponse<TIdType> 
        where TDTO : BaseDTO<TIdType>
    {
        TVMResponse MapFromDTOToVM(TDTO dto);
        List<TVMResponse> MapFromDTOToVM(List<TDTO> listDTO);
        PagedResult<TVMResponse> MapFromDTOToVM(PagedResult<TDTO> pagedResultDTO);
    }
}
