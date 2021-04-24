using HBCaseStudy.Business.Abstract;
using HBCaseStudy.Business.Abstract.Factories;
using HBCaseStudy.Business.Abstract.Services;
using HBCaseStudy.Business.Factories;
using HBCaseStudy.Model;
using HBCaseStudy.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HBCaseStudy.Business.Services
{
    public class RoverService : IRoverService
    {
        #region ctor & member

        private readonly IMarsFactory marsFactory;

        private readonly ILoggingService logger;

        public RoverService(IMarsFactory marsFactory, ILoggingService logger)
        {
            this.marsFactory = marsFactory;
            this.logger = logger;
        }

        #endregion

        public void Run(string roverName, int startPointHorizontal, int startPointVertical, string startDirection, string destinationCommands)
        {
            var plateauArea = marsFactory.CreatePlateauRectangle(5, 5);

            var rover = marsFactory.CreateRover(roverName, startPointHorizontal, startPointVertical, startDirection);

            StartProcessLog(roverName, startPointHorizontal, startPointVertical, startDirection, destinationCommands);

            StartRuningRoboticRover(plateauArea, destinationCommands, rover);

            EndProcessLog(rover);
        }

        private void StartRuningRoboticRover(IEnumerable<int> plateauArea, string destinationCommands, Rover rover)
        {
            foreach (var command in destinationCommands)
            {
                var movement = (Movement)Enum.Parse(typeof(Movement), command.ToString());

                var roverOperation = CreateOperationStrategy(movement);

                roverOperation.SetMovement(rover, movement);

                if (CheckAreaPosition(plateauArea, rover))
                {
                    throw new IndexOutOfRangeException($"Oops! Position can not be beyond bounderies (0 , 0) and ({plateauArea.ElementAt(0)} , {plateauArea.ElementAt(1)})");
                }
            }
        }

        private IOperationStrategy roverStrategy;

        private IOperationStrategy CreateOperationStrategy(Enum movementEnum)
        {
            if (roverOperations.Value.TryGetValue(movementEnum, out Func<IOperationStrategy> func))
            {
                roverStrategy = func.Invoke();
            }

            return roverStrategy ?? default;
        }

        private readonly Lazy<Dictionary<Enum, Func<IOperationStrategy>>> roverOperations = new Lazy<Dictionary<Enum, Func<IOperationStrategy>>>(() =>
                new Dictionary<Enum, Func<IOperationStrategy>>()
                {
                    { Movement.L,  () => { return new RoverRotateLeft(); } },
                    { Movement.R,  () => { return new RoverRotateRight(); } },
                    { Movement.M,  () => { return new RoverMoveForward(); } }
                }
            );

        private bool CheckAreaPosition(IEnumerable<int> plateauArea, Rover rover)
        {
            return rover.Horizontal < 0
                || rover.Horizontal > plateauArea.ElementAt(0)
                || rover.Vertical < 0
                || rover.Vertical > plateauArea.ElementAt(1);
        }

        #region log helper

        private void StartProcessLog(string roverName, int startPointHorizontal, int startPointVertical, string startDirection, string commands)
        {
            var message = $"{roverName} tour start. Location: {startPointHorizontal} {startPointVertical} {startDirection}. Commands: {commands} \n";

            CreateLog(message);
        }

        private void EndProcessLog(Rover rover)
        {
            var message = $"{rover.RoverName} tour end. New Location: {rover.LocationInfo} \n";

            CreateLog(message);
        }

        private void CreateLog(string message)
        {
            logger.LogInformation(SetMethodNameForLogMessage(nameof(Run)), $"{message} \n");
        }

        private string SetMethodNameForLogMessage(string methodName)
        {
            return $"{GetType().Name}.{methodName}";
        }

        #endregion
    }
}