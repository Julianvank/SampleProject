using Application;
using Application.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Extensions;

namespace Console;

public static class Program
{
    private static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddPersistence();

        await using (var serviceProvider = services.BuildServiceProvider())
        {
            var uow = serviceProvider.GetService<IUnitOfWork>();

            await uow.DropAndRoll();
            
            var seeder = new DataSeeder(uow);
            await seeder.Seed();
            

        }

        await using (var serviceProvider = services.BuildServiceProvider())
        {
            var uow = serviceProvider.GetService<IUnitOfWork>();

            var stocks = await uow.StocksRepository.GetAllAsync();
            var indices = await uow.IndicesRepository.GetAllAsync();


            if (!indices.Any())
            {
                System.Console.WriteLine("There are no indices");
            }
            foreach (var s in stocks)
            {
                System.Console.WriteLine(s.ToString());
            }

            foreach (var i in indices)
            {
                System.Console.WriteLine(i.ToString());
            }
        }
    }
}