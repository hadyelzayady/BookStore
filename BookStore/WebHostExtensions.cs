using BookStore.Models;
using BookStore.Seeders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class ModelBuilderExtensions
{
    public static IWebHost SeedData(this IWebHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetService<BookStoreContext>();

            context.Database.Migrate();

             new CategoriesSeeders(context).SeedData();
        }
        return host;
    }
}