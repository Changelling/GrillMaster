using GrillMaster.Application;
using GrillMaster.Application.GrillMenu.Commands.CalculateSchedule;
using GrillMaster.Application.GrillMenu.Queries.GetGrillMenu;
using GrillMaster.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            IMediator Mediator = serviceProvider.GetService<IMediator>();

            GetGrillMenuQuery menuQuery = new GetGrillMenuQuery();
            var menus = await Mediator.Send(menuQuery);

            CalculateScheduleCommand scheduleCommand = new CalculateScheduleCommand()
            {
                GrillMeasure = new System.Drawing.Size(20, 30),
                Menus = menus
            };
            var planning = await Mediator.Send(scheduleCommand);
            foreach (var plan in planning.Menus)
            {
                Console.WriteLine($"{plan.Name}: {plan.Rounds} rounds");
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure();
            //services.AddLogging(configure => configure.AddConsole());
        }
    }
}
