using System;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            // Bu kısım proje çalıştırıldığında eğer data contextte bir değişiklik var ise bunu data base e aktarıyor
            //
            var host=CreateHostBuilder(args).Build();
            using (var scope=host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                //olası hataları yakalamak ıcın logger factory servisi çağırılıyor. catch blogunda da olası hata durumunda hata geliştiriciye gösteriliyor.
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    //alttaki kod migration oluşturulacak context'i bulup context değişkenine atıyor.
                    var context = services.GetRequiredService<StoreContext>();

                    //üst tarafta açıklanan context ile data base oluşturmak için bağlantı adresi nokta database nokta migration kullanılıyor tabiki işlemin süresi boyunca program durdurulmaması için async olarak yapılıyor.
                    await context.Database.MigrateAsync();

                    //Burada hazır verileri data base e yolluyoruz.
                    await StoreContextSeed.SeedAsync(context, loggerFactory);


                    var userManager = services.GetRequiredService<UserManager<AppUser>>();
                    var identityContext = services.GetRequiredService<AppIdentityDbContext>();
                    await identityContext.Database.MigrateAsync();
                    await AppIdentityDbContextSeed.SeedUserAsync(userManager);

                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex,"An error occurred during migration");
                }
               
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
