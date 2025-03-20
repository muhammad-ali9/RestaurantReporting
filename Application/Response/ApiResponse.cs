using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            
        }

        // Success

        public ApiResponse(T data, string? message = null)
        {
            Success = true;
            Message = message;
            Data = data;
        }

        //Failure
        public ApiResponse(string message )
        {
            Message = message;
            Success = false;

        }

        //Login


        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
