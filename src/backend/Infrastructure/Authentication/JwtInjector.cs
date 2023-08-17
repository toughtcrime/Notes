using Application.Services;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication
{
    public static class Jwt
    {
        public static void AddJwt(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
        }
    }
}
