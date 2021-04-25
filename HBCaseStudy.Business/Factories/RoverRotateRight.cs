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
                    rover.SetDirectionEast();
                    break;

                case Direction.S:
                    rover.SetDirectionWest();
                    break;

                case Direction.E:
                    rover.SetDirectionSouth();
                    break;

                case Direction.W:
                    rover.SetDirectionNorth();
                    break;

                default:
                    break;
            }
        }
    }
}