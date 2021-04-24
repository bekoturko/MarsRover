using HBCaseStudy.Business.Abstract.Factories;
using HBCaseStudy.Model;
using HBCaseStudy.Model.Entities;

namespace HBCaseStudy.Business.Factories
{
    public class RoverRotateLeft : IOperationStrategy
    {
        public void SetMovement(Rover rover, Movement movement)
        {
            switch (rover.Direction)
            {
                case Direction.N:
                    rover.Direction = Direction.W;
                    break;

                case Direction.S:
                    rover.Direction = Direction.E;
                    break;

                case Direction.E:
                    rover.Direction = Direction.N;
                    break;

                case Direction.W:
                    rover.Direction = Direction.S;
                    break;

                default:
                    break;
            }
        }
    }
}