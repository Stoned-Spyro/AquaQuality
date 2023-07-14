using AquaQuality.DAL.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AquaQuality.BLL.Profiles;
using AquaQuality.BLL.Services;
using AquaQuality.DAL.Interfaces;
using AquaQuality.DAL.Interfaces.Measurements;
using AquaQuality.DAL.Interfaces.WaterStorages;
using AquaQuality.DAL.Repositories;
using AquaQuality.DAL.Entities;
using AquaQuality.BLL.Settings;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Text;

namespace AquaQuality.WEB
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
            services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(
                o => o.UseNpgsql(Configuration.GetConnectionString("DbConection")));

            services.AddCors(options =>
            {
                options.AddPolicy(name: "_mainOrigins",
                    policy =>
                    {
                        //policy.WithOrigins("https://aqua-quality.herokuapp.com").AllowAnyHeader().AllowAnyMethod();
                        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });

            //Configure jwt 
            services.Configure<JWT>(Configuration.GetSection("JWT"));

            //Configured services
            services.AddTransient<IMeasurementsRepository, MeasurementsRepository>();
            services.AddTransient<IWaterStorageRepository, WaterStorageRepository>();

            services.AddTransient<IWaterStorageService, WaterStorageService>();
            services.AddTransient<IMeasurementService, MeasurementService>();
            services.AddTransient<IUserService, UserService>();

            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>();

            services.AddAutoMapper(typeof(MainProfile).Assembly);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                };
            });

            services.AddControllers();
 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AquaQuality.WEB", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AquaQuality.WEB v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("_mainOrigins");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
