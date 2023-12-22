using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Global
{
    public class BaseResponse<T>
    {
        public int CodigoDeError { get; set; }
        public string Mensaje { get; set; }
        public List<T> Response { get; set; }
    }
}
