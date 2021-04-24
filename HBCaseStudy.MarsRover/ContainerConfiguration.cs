using HBCaseStudy.Business.Abstract;
using HBCaseStudy.Business.Abstract.Factories;
using HBCaseStudy.Business.Abstract.Services;
using HBCaseStudy.Business.Factories;
using HBCaseStudy.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HBCaseStudy.MarsRover
{
    internal static class ContainerConfiguration
    {
        public static ServiceProvider Configure()
        {
            return new ServiceCollection()
                .AddLogging(l => l.AddConsole())
                .Configure<LoggerFilterOptions>(c => c.MinLevel = LogLevel.Trace)
                .AddSingleton<ILoggingService, LoggingService>()
                .AddSingleton<IRoverService, RoverService>()
                .AddSingleton<IMarsFactory, MarsFactory>()
                .BuildServiceProvider();
        }
    }
}