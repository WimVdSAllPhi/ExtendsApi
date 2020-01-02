using System.Text.Json.Serialization;

namespace ExtendsApi.Models
{
    public class ErrorResponse
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ErrorType Type { get; set; }
        public string Message { get; set; }
    }

    public enum ErrorType
    {
        ValidationError,
        BusinessLogicError,
        Exception,
        NotFound
    }
}
