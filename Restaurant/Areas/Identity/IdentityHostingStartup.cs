using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Restaurant.Areas.Identity.Data;
using Restaurant.Models;

[assembly: HostingStartup(typeof(Restaurant.Areas.Identity.IdentityHostingStartup))]
namespace Restaurant.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RestaurantContext>(options => options.UseSqlite("Filename=MyDatabase.db"));
                services.AddDefaultIdentity<RestaurantUser>().AddRoles<IdentityRole>().AddEntityFrameworkStores<RestaurantContext>()
                    .AddDefaultTokenProviders();
            });
        }
    }
}