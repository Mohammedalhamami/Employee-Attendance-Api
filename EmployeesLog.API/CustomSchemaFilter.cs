using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EmployeesLog.API
{
    public class CustomSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
             if(context.Type == typeof(DateOnly))
            {
                schema.Type = "string";
                schema.Format = "date";
                schema.Properties.Clear();
            }
            if (context.Type == typeof(DateTime))
            {
                schema.Type = "string";
                schema.Format = "date-time";
                schema.Properties.Clear();
            }
        }
    }
}
