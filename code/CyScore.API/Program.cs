using CyScore.API.Interfaces;
using CyScore.API.Services;
using CyScore.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CyScore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //data services
            builder.Services.AddCyscoreDataServices();
            builder.Services.AddDbContextPool<CyScoreContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("CyscoreDBConnection")));

            //api services
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAgentService, AgentService>();
            builder.Services.AddScoped<IStationService, StationService>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "*",
                    policy =>
                    {
                        policy.WithOrigins("*");
                        policy.WithHeaders("*");
                    });
            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("*");
            app.MapControllers();

            app.Run();
        }
    }
}