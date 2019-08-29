using System;
using Microsoft.Extensions.DependencyInjection;
using PetShopApp.Core.ApplicationService;
using PetShopApp.Core.ApplicationService.Impl;
using PetShopApp.Core.DomainService;
using PetShopApp.Infrastructure.Static.Data;
using PetShopApp.Infrastructure.Static.Data.Repositories;

namespace PetShop
{
    public class Program 
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IOwnerRepository, OwnerRepository>();
            serviceCollection.AddScoped<IOwnerService, OwnerService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();
            var ownerService = serviceProvider.GetRequiredService<IOwnerService>();
            
            var instance = new Printer(petService, ownerService);
            instance.Run();
        }
    }
}
