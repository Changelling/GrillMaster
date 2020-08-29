using AutoMapper;
using GrillMaster.Application.Common.Interfaces;
using GrillMaster.Application.GrillMenu.Commands.CalculateSchedule;
using GrillMaster.Application.GrillMenu.Interfaces;
using GrillMaster.Infrastructure.BinPack;
using GrillMaster.Infrastructure.BinPack._2D;
using GrillMaster.Infrastructure.BinPack.Enums;
using GrillMaster.Infrastructure.BinPack.Heuristic;
using GrillMaster.Infrastructure.BinPack.Interfaces;
using GrillMaster.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing;
using System.Reflection;

namespace GrillMaster.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddHttpClient<IGrillMenuClient, GrillMenuClient>();
            services.AddTransient<IDateTime, DateTimeService>();
            //Register Factories
            services.AddTransient<IBinFactory, BinFactory>();
            services.AddTransient<MaxRectsBinPack>()
                        .AddScoped<IBin, MaxRectsBinPack>(s => s.GetService<MaxRectsBinPack>());

            services.AddTransient<IHeuristicFactory, HeuristicFactory>();
            services.AddScoped<BottomLeftHeuristic>()
                        .AddScoped<IHeuristic, BottomLeftHeuristic>(s => s.GetService<BottomLeftHeuristic>());
            //Register Packer
            services.AddTransient<IBinPack>(s =>
                new BinPack.BinPack(s.GetRequiredService<IBinFactory>(), s.GetRequiredService<IHeuristicFactory>(),
                EBinPackStrategy.MaxRect, ERectangleHeuristic.RectBottomLeftRule));
            services.AddTransient<IGrillCalculator, GrillCalculatorService>();
            return services;
        }
    }
}
