using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HolyChildhood
{
    public static class StartupAuth
    {
        private const string META_DATA_ADDRESS_FORMATTER = "https://login.microsoftonline.com/{0}/v2.0/.well-known/openid-configuration?p={1}";
        private const string TENANT_FORMATTER = "{0}.onmicrosoft.com";

        public static void AddAzureB2CAuthentication(this IServiceCollection services, string policy, string tenant,
            string audience, bool isDevelopment)
        {
            var myTenant = string.Format(TENANT_FORMATTER, tenant);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.MetadataAddress = string.Format(META_DATA_ADDRESS_FORMATTER, myTenant, policy);
                o.Audience = audience;
                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();
                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";

                        if (isDevelopment)
                        {
                            return c.Response.WriteAsync(c.Exception.ToString());
                        }

                        return c.Response.WriteAsync("An error occured processing your authentication.</br>\r\n" +
                                                     c.Exception.ToString());
                    }
                };
            });
        }
    }
}