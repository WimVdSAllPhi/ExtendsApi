using ExtendsApi.BusinessLayer.DTOs;
using ExtendsApi.BusinessLayer.Filters;
using ExtendsApi.DataLayer.Models;
using ExtendsApi.Models;
using System.Collections.Generic;

namespace ExtendsApi.BusinessLayer.Services.Interfaces
{
    public interface IBaseService<IdType, TKeyFilter, TEntity, TDTO, TDTOFilter> 
        where IdType : struct 
        where TKeyFilter : class 
        where TEntity : BaseEntity<IdType> 
        where TDTO : BaseDTO<IdType> 
        where TDTOFilter : BaseDTOFilter<TKeyFilter>
    {
        #region Getters
        Response<TDTO> GetById(IdType id);

        Response<List<TDTO>> GetAll();
        Response<PagedResult<TDTO>> GetAll(int page, int pageSize);

        #endregion

        #region Actions

        Response<TDTO> Create(TDTO dto, string userName);
        Response<TDTO> Update(TDTO dto, string userName);
        Response<TDTO> SoftDelete(IdType id);

        #endregion
    }
}
