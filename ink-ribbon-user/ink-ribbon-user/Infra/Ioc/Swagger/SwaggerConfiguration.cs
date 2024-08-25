using Microsoft.OpenApi.Models;

namespace ink_ribbon_user.Infra.Ioc.Swagger
{
    public class SwaggerConfiguration
    {
        public static void AddSwagger(IServiceCollection _collection)
        {
            _collection.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("v1", new OpenApiInfo { Title = "BobMarley", Version = "v1" });
                options.ResolveConflictingActions(d => d.First());

            });
        }
    }
}

