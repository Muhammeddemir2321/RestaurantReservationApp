using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Reservation.Shared.DTO_s
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public ErrorDto Error { get; set; }
        public static ResponseDto<T> Succes(T data, int statusCode)
        {
            return new ResponseDto<T> { Data = data, StatusCode = statusCode };
        }
        public static ResponseDto<T> Succes(int statusCode)
        {
            return new ResponseDto<T> { StatusCode = statusCode };
        }
        public static ResponseDto<T> Fail(ErrorDto errorDto, int statusCode)
        {
            return new ResponseDto<T> { Error = errorDto, StatusCode = statusCode };
        }
        public static ResponseDto<T> Fail(string error, int statusCode, bool isShow)
        {
            var errorDto = new ErrorDto(error, isShow);

            return new ResponseDto<T> { Error = errorDto, StatusCode = statusCode};
        }
    }
}
