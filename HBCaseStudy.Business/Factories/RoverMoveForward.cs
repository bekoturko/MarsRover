using HBCaseStudy.Business.Abstract.Factories;
using HBCaseStudy.Model;
using HBCaseStudy.Model.Entities;

namespace HBCaseStudy.Business.Factories
{
    public class RoverMoveForward : IOperationStrategy
    {
        public void SetMovement(Rover rover, Movement movement)
        {
            switch (rover.Direction)
            {
                case Direction.N:
                    rover.Vertical += 1;
                    break;

                case Direction.S:
                    rover.Vertical -= 1;
                    break;

                case Direction.E:
                    rover.Horizontal += 1;
                    break;

                case Direction.W:
                    rover.Horizontal -= 1;
                    break;

                default:
                    break;
            }
        }
    }
}