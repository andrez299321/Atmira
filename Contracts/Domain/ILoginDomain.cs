using Dto.Controller;
using Dto.Global;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Business
{
    public interface ILoginBusiness
    {
        Task<BaseResponse<LoginResponse>> Login(LoginRequest login);
    }
}
