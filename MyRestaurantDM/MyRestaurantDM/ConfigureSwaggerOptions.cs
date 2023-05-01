using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MyRestaurantDM
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }
        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
          foreach (var item in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(item.GroupName, CreateVersionInfo(item));
            }
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription item)
        {
            var info = new OpenApiInfo
            {
                Title = "Your versioned API",
                Version = item.ApiVersion.ToString()
            };

            return info;
        }
    }
}
