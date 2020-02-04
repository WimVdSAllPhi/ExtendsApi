using ExtendsApi.BusinessLayer.DTOs;
using ExtendsApi.BusinessLayer.Filters;
using ExtendsApi.BusinessLayer.Mapper.Interfaces;
using ExtendsApi.BusinessLayer.Services.Interfaces;
using ExtendsApi.DataLayer.Models;
using ExtendsApi.DataLayer.Repository.Interfaces;
using ExtendsApi.Models;
using System;
using System.Collections.Generic;

namespace ExtendsApi.BusinessLayer.Services
{
    public class BaseService<IdType, TKeyFilter, TEntity, TDTO, TDTOFilter> : IBaseService<IdType, TKeyFilter, TEntity, TDTO, TDTOFilter>
        where IdType : struct 
        where TKeyFilter : class 
        where TEntity : BaseEntity<IdType> 
        where TDTO : BaseDTO<IdType> 
        where TDTOFilter : BaseDTOFilter<TKeyFilter>
    {
        private readonly IBaseRepository<TEntity, IdType> _repository;
        private readonly IMapper<IdType, TEntity, TDTO> _mapper;

        public BaseService(IBaseRepository<TEntity, IdType> repository, IMapper<IdType, TEntity, TDTO> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region Getters

        public Response<TDTO> GetById(IdType id)
        {
            try
            {
                var item = _repository.GetByOne(x => x.IsDeleted == false && x.Id.Equals(id));
                if (item == null)
                    return new Response<TDTO>().AddNotFoundMessage($"The {nameof(TEntity)} with id {id} doesn't exist or is Deleted.");

                var itemDTO = _mapper.MapFromEntityToDTO(item);
                return new Response<TDTO>() { Model = itemDTO };
            }
            catch (Exception ex)
            {
                return new Response<TDTO>().AddException(ex);
            }
        }

        public Response<List<TDTO>> GetAll()
        {
            try
            {
                var list = _repository.GetAll();
                if (list == null)
                    return new Response<List<TDTO>>().AddNotFoundMessage($"There aren't {nameof(TEntity)}.");

                var listDTO = _mapper.MapFromEntityToDTO(list);

                return new Response<List<TDTO>> { Model = listDTO };
            }
            catch (Exception ex)
            {
                return new Response<List<TDTO>>().AddException(ex);
            }
        }

        public Response<PagedResult<TDTO>> GetAll(int page, int pageSize)
        {
            try
            {
                var list = _repository.GetAllByPagination(page, pageSize);
                if (list == null)
                    return new Response<PagedResult<TDTO>>().AddNotFoundMessage($"There aren't {nameof(TEntity)}.");

                var listDTO = _mapper.MapFromEntityToDTO(list);

                return new Response<PagedResult<TDTO>> { Model = listDTO };
            }
            catch (Exception ex)
            {
                return new Response<PagedResult<TDTO>>().AddException(ex);
            }
        }

        #endregion

        #region Actions

        public Response<TDTO> Create(TDTO dto, string userName)
        {
            try
            {
                // Todo: Put Name
                dto.CreatedBy = userName;
                dto.CreatedDate = DateTime.Now;

                var entity = _mapper.MapFromDTOToEntity(dto);
                var response = _repository.Create(entity);
                var rows = _repository.SaveChanges();

                if (rows >= 0)
                {
                    dto = _mapper.MapFromEntityToDTO(response);
                    return new Response<TDTO> { Model = dto };
                }

                return new Response<TDTO>().AddBusinessLogicErrorMessage($"The {nameof(TEntity)} isn't saved.");
            }
            catch (Exception ex)
            {
                return new Response<TDTO>().AddException(ex);
            }
        }

        public Response<TDTO> Update(TDTO dto, string userName)
        {
            try
            {
                // Todo: Put Name
                dto.ChangedBy = userName;
                dto.ChangedDate = DateTime.Now;

                var enity = _mapper.MapFromDTOToEntity(dto);
                var response = _repository.Edit(enity);
                var rows = _repository.SaveChanges();

                if (rows >= 0)
                {
                    dto = _mapper.MapFromEntityToDTO(response);
                    return new Response<TDTO> { Model = dto };
                }

                return new Response<TDTO>().AddBusinessLogicErrorMessage($"The {nameof(TEntity)} isn't updated.");
            }
            catch (Exception ex)
            {
                return new Response<TDTO>().AddException(ex);
            }
        }

        public Response<TDTO> SoftDelete(IdType id)
        {
            try
            {
                var response = _repository.SoftDelete(id);
                var rows = _repository.SaveChanges();

                if (rows >= 0)
                {
                    var dto = _mapper.MapFromEntityToDTO(response);
                    return new Response<TDTO> { Model = dto };
                }

                return new Response<TDTO>().AddBusinessLogicErrorMessage($"The {nameof(TEntity)} isn't deleted.");
            }
            catch (Exception ex)
            {
                return new Response<TDTO>().AddException(ex);
            }
        }

        #endregion
    }
}
