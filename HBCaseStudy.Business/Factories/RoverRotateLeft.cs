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
                    rover.SetDirectionWest();
                    break;

                case Direction.S:
                    rover.SetDirectionEast();
                    break;

                case Direction.E:
                    rover.SetDirectionNorth();
                    break;

                case Direction.W:
                    rover.SetDirectionSouth();
                    break;

                default:
                    break;
            }
        }
    }
}