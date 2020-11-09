using AspNetCore.Identity.MongoDbCore.Extensions;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using Furny.Model;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MongoIdentityConfiguration
    {
        public static IServiceCollection AddMongoIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var dbName = configuration.GetValue<string>("DbName");

            var mongoDbIdentityConfiguration = new MongoDbIdentityConfiguration
            {
                MongoDbSettings = new MongoDbSettings
                {
                    ConnectionString = configuration.GetConnectionString(dbName),
                    DatabaseName = dbName
                },
                IdentityOptionsAction = options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;

                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                    options.Lockout.MaxFailedAccessAttempts = 10;

                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@.-_";
                }
            };

            services.ConfigureMongoDbIdentity<ApplicationUser, ApplicationRole, ObjectId>(mongoDbIdentityConfiguration);

            return services;
        }
    }
}
