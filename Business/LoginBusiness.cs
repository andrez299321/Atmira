using Contracts.Business;
using Contracts.Infraestructure;
using Dto.Controller;
using Dto.Global;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class LoginBusiness:ILoginBusiness
    {
        private readonly ITokenService _tokenServices;
        private readonly IConfiguration _configuration;
        public LoginBusiness(ITokenService tokenServices, IConfiguration configuration)
        {
            _tokenServices = tokenServices;
            _configuration = configuration;
        }
        public async Task<BaseResponse<LoginResponse>> Login(LoginRequest login)
        {
            BaseResponse<LoginResponse> result = null;

            if (login.Correo.Equals("admin@gmail.com") && login.Password.Equals("12345"))
            {
                string token = _tokenServices.BuildToken(_configuration["Jwt:Key"], _configuration["Jwt:Issuer"], login);

                var obj = new LoginResponse()
                {
                    Token = token
                };
                List<LoginResponse> list = new List<LoginResponse>();
                list.Add(obj);

                result = new BaseResponse<LoginResponse>()
                {
                    CodigoDeError = 0,
                    Mensaje = "OK",
                    Response = list
                };
            }
            else
            {
                result = new BaseResponse<LoginResponse>()
                {
                    CodigoDeError = 99,
                    Mensaje = "usuario o password incorrecto",
                    Response = null
                };
            }
            return result;
        }
    }
}
