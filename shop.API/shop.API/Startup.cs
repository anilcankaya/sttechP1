using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using shop.API.Data;
using shop.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace shop.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "shop.API", Version = "v1" });
            });

            services.AddScoped<IProductService, EFProductService>();
            services.AddDbContext<ShopdbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("db")));
            services.AddScoped<IUserService, FakeUserService>();

            /*
             * farklı orijinler:
             * http://dukkan.trendyol.com <-> http://www.trendyol.com 
             * https://www.trendyol.com <-> http://www.trendyol.com 
             * http://www.trendyol.com:2016 <-> http://www.trendyol.com 
             * 
             * Aynı:
             *    * https://www.trendyol.com/urunler <> https://www.trendyol.com/kategoriler
             * 
             */

            services.AddCors(option =>
            {
                option.AddPolicy("allow", config =>
                {
                    config.AllowAnyHeader();
                    config.AllowAnyMethod();
                    config.AllowAnyOrigin();
                });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //services.AddAuthentication("Basic").AddScheme<>

            var auidience = Configuration.GetSection("TokenParam")["Audience"];
            var issuer = Configuration.GetSection("TokenParam")["Issuer"];
            var secret = Configuration.GetSection("TokenParam")["Secret"];


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(opt =>
                    {
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateActor = true,
                            ValidateAudience = true,
                            ValidateIssuer = true,
                            ValidAudience = auidience,
                            ValidIssuer = issuer,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))

                        };
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "shop.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("allow");

            app.UseAuthentication();

            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
