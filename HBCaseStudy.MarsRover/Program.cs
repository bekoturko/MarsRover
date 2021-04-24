using HBCaseStudy.Business.Abstract;
using HBCaseStudy.Business.Abstract.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HBCaseStudy.MarsRover
{
    public class Program
    {
        static void Main()
        {
            SetGlobalExceptionHandler();

            var serviceProvider = SetupDependencyInjection();

            var logger = serviceProvider.GetService<ILoggingService>();

            logger.LogDebug(nameof(Main), "Application Started.. \n");

            var roverService = serviceProvider.GetService<IRoverService>();

            //Rover 1
            roverService.Run("Alpha", 1, 2, "N", "LMLMLMLMM");

            //Rover 2
            roverService.Run("Bravo", 3, 3, "E", "MMRMMRMRRM");

            logger.LogDebug(nameof(Main), "All done! \n");

            Console.ReadKey();
        }

        private static ServiceProvider SetupDependencyInjection()
        {
            return ContainerConfiguration.Configure();
        }

        private static void SetGlobalExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += GlobalUnhandledExceptionHandler;
        }

        private static void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Opps! Something Happened..");
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}