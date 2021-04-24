using HBCaseStudy.Business.Abstract.Factories;
using HBCaseStudy.Model;
using HBCaseStudy.Model.Entities;

namespace HBCaseStudy.Business.Factories
{
    public class RoverRotateRight : IOperationStrategy
    {
        public void SetMovement(Rover rover, Movement movement)
        {
            switch (rover.Direction)
            {
                case Direction.N:
                    rover.Direction = Direction.E;
                    break;

                case Direction.S:
                    rover.Direction = Direction.W;
                    break;

                case Direction.E:
                    rover.Direction = Direction.S;
                    break;

                case Direction.W:
                    rover.Direction = Direction.N;
                    break;

                default:
                    break;
            }
        }
    }
}