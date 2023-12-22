using Atmira.ExtensionServices;
using Contracts.Business;
using Contracts.Infraestructure;
using Contracts.Repository;
using Database;
using Database.Repository;
using Business;
using Dto.Global;
using Infraestructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Text;
using Utility;
using Utility.Mapper;

namespace Atmira
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(UtilityProfile));
            
            services.AddDbContext<AtmiraContext>(
                 options => options.UseSqlServer(Configuration.GetConnectionString("Database"))
            );
            services.Configure<Dto.Global.Services>(options => Configuration.GetSection("services").Bind(options));
            services.Configure<GLog>(options => Configuration.GetSection("log").Bind(options));
            Conexion.Log = Configuration.GetSection("log").GetChildren().Where(x => x.Key.Equals("Route")).FirstOrDefault().Value; 
            var url = Configuration.GetSection("services").GetChildren().Where(x=>x.Key.Equals("TvMaze")).FirstOrDefault().Value;
            
            services.AddHttpClient("Backend",
                client => {
                    client.BaseAddress = new Uri(url);
                }
            );

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };

            });

            InjectServices(services);
            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerApp(apiDescriptionProvider);

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void InjectServices(IServiceCollection services)
        {
            services.AddScoped<ITvShowBusiness, TvShowBusiness>();
            services.AddScoped<ITvShowApi, TvShowApi>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddScoped<ILoginBusiness, LoginBusiness>();

            services.AddScoped<IRTvShow, RTvShow>();
            services.AddScoped<IRSelves, RSelves>();
            services.AddScoped<IRSchedules, RSchedules>();
            services.AddScoped<IRRatings, RRatings>();
            services.AddScoped<IRLinks, RLinks>();
            services.AddScoped<IRImages, RImages>();
            services.AddScoped<IRNetworks, RNetworks>();
            services.AddScoped<IRExternals, RExternals>();
            services.AddScoped<IRCountries, RCountries>();




        }
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Atmira {groupName}",
                    Version = groupName,
                    Description = "Jairo Andres Camargo Vargas",
                    Contact = new OpenApiContact
                    {
                        Name = "Atmira",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
        }
    }
}
