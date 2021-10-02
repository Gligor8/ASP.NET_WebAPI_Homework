using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Domain;
using System;

namespace MovieApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services)
        {
            services.AddDbContext<MovieAppDbContext>(x =>
                x.UseSqlServer($@"Server=LAPTOP-CJ4TGOP3\SQLEXPRESS;Database=MovieAppDb;Trusted_Connection=True"));
        }
    }
}
