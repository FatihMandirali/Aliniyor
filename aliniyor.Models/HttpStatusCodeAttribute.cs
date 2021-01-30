using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace aliniyor.Models
{
    public class HttpStatusCodeAttribute : Attribute
    {
        public HttpStatusCode StatusCode { get; }

        internal HttpStatusCodeAttribute(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
