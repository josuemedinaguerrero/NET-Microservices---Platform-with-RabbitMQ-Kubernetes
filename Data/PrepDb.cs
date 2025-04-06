using PlatformService.Models;

namespace PlatformService.Data
{
   public static class PrepDb
   {
      public static void PrepPopulation(IApplicationBuilder app)
      {
         using var serviceScope = app.ApplicationServices.CreateScope();
         var context = serviceScope.ServiceProvider.GetService<AppDbContext>() ?? throw new Exception("DbContext is not registered!");
         SeedData(context);
      }

      private static void SeedData(AppDbContext context)
      {
         if (!context.Platforms.Any())
         {
            Console.WriteLine("--> Seeding Data...");

            context.Platforms.AddRange(
               new Platform() { Name = "Data 1", Publisher = "Publisehr 1", Cost = "Free" },
               new Platform() { Name = "Data 2", Publisher = "Publisehr 2", Cost = "Free" },
               new Platform() { Name = "Data 3", Publisher = "Publisehr 3", Cost = "Free" }
            );

            context.SaveChanges();
         }
         else
         {
            Console.WriteLine("--> We already have data!");
         }
      }
   }
}
