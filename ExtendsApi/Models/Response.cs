using System;
using System.Collections.Generic;

namespace ExtendsApi.Models
{
    public class Response<TModel>
    {
        public Response()
        {
            Errors = new List<ErrorResponse>();
        }
        //public Response(ErrorType type, string errorMessage)
        //{
        //    Errors = new List<ErrorResponse>() { new ErrorResponse { Type = type, Message = errorMessage } };
        //}

        public bool DidError => Errors == null || Errors.Count <= 0 ? false : true;
        public ICollection<ErrorResponse> Errors { get; set; }
        public TModel Model { get; set; }
    }

    public static class ExtensionsForResponse
    {
        // Add exception error
        public static Response<TModel> AddException<TModel>(this Response<TModel> response, Exception ex)
        {
            response.Errors.Add(new ErrorResponse { Type = ErrorType.Exception, Message = ex.Message });

            if (ex.InnerException != null)
            {
                response.AddException(ex.InnerException);
            }
            return response;
        }

        // Add business logic errors
        public static Response<TModel> AddBusinessLogicErrorMessage<TModel>(this Response<TModel> response, string message)
        {
            response.Errors.Add(new ErrorResponse { Type = ErrorType.BusinessLogicError, Message = message });
            return response;
        }
        public static Response<TModel> AddBusinessLogicErrorMessage<TModel>(this Response<TModel> response, IEnumerable<string> messages)
        {
            foreach (var message in messages)
                response.AddBusinessLogicErrorMessage(message);
            return response;
        }

        // Add validation errors
        public static Response<TModel> AddValidationMessage<TModel>(this Response<TModel> response, string message)
        {
            response.Errors.Add(new ErrorResponse { Type = ErrorType.ValidationError, Message = message });
            return response;
        }
        public static Response<TModel> AddValidationMessages<TModel>(this Response<TModel> response, IEnumerable<string> messages)
        {
            foreach (var message in messages)
                response.AddValidationMessage(message);
            return response;
        }

        // Add NotFound error
        public static Response<TModel> AddNotFoundMessage<TModel>(this Response<TModel> response, string message)
        {
            response.Errors.Add(new ErrorResponse { Type = ErrorType.NotFound, Message = message });
            return response;
        }
    }
}
