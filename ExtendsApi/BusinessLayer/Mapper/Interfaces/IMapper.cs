using ExtendsApi.BusinessLayer.DTOs;
using ExtendsApi.DataLayer.Models;
using ExtendsApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ExtendsApi.BusinessLayer.Mapper.Interfaces
{
    public interface IMapper<IdType, TEntity, TDTO>
        where IdType : struct
        where TEntity : BaseEntity<IdType> 
        where TDTO : BaseDTO<IdType>         
    {
        TEntity MapFromDTOToEntity(TDTO dto);
        TDTO MapFromEntityToDTO(TEntity entity);
        List<TDTO> MapFromEntityToDTO(IQueryable<TEntity> entityList);
        PagedResult<TDTO> MapFromEntityToDTO(PagedResult<TEntity> pagedResultEntity);
    }
}
