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
                    rover.SetVerticalIncrease();
                    break;

                case Direction.S:
                    rover.SetVerticalDecrease();
                    break;

                case Direction.E:
                    rover.SetHorizontalIncrease();
                    break;

                case Direction.W:
                    rover.SetHorizontalDecrease();
                    break;

                default:
                    break;
            }
        }
    }
}