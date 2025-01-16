using DemoMultiTenantDotNet9.Infrastructure;
using Microsoft.AspNetCore.Hosting;

namespace DemoMultiTenantDotNet9.Middlewares
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IDbContextConnectionStringProvider connectionStringProvider)
        {
            var tenantName = context.Request.Headers["Tenant"].FirstOrDefault();

            if (!string.IsNullOrEmpty(tenantName))
            {
                //context.Response.StatusCode = 400; // Bad Request
                string generalConn = @"Server=MyServer;Initial Catalog={DatabaseName};Trusted_Connection=True;MultipleActiveResultSets=true;trustServerCertificate=true";

                var connectionString = generalConn.Replace("{DatabaseName}", tenantName);
                connectionStringProvider.ConnectionString = connectionString;
                context.Items["Tenant"] = tenantName;

            }



            await _next(context);
        }
    }
}
