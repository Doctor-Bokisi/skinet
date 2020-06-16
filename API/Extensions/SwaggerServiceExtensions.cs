using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Skinet API", Version = "v1"});
            });
            
            return services;
        }

        public static IApplicationBuilder UseSwaggerDocummentation(this IApplicationBuilder app)
        {
            app.UseSwagger(); // Allows us to browse a web page that shows all our endpoints

            app.UseSwaggerUI(c => {c.SwaggerEndpoint("/swagger/v1/swagger.json","Skinet API v1");});
            // Allows us to browse a web page that shows all our endpoints
            return app;
            
        }
    }
}