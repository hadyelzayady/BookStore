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

            // now we have the DbContext. Run migrations
            context.Database.Migrate();

            // now that the database is up to date. Let's seed
             new CategoriesSeeders(context).SeedData();

//#if DEBUG
//            // if we are debugging, then let's run the test data seeder
//            // alternatively, check against the environment to run this seeder
//            new TestDataSeeder(context).SeedData();
//#endif
        }
        return host;
    }
}