using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public required HttpStatusCode StatusCode { get; set; }
    }
}
