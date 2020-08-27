using API.Validation;
using Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repository;
using Service;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(cfg =>
                cfg.RegisterValidatorsFromAssemblyContaining<RouletteBetPayloadValidation>().
                    RegisterValidatorsFromAssemblyContaining<RouletteCreatePayloadValidation>());
            services.AddScoped<IRedisData, RedisData>();
            services.AddScoped<IRedisRepository, RedisRepository>();
            services.AddScoped<IRouletteService, RouletteService>();
            services.AddScoped<IRouletteService, RouletteService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Masivian API", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IRedisData redisService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            redisService.Connect();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
