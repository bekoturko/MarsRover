using HBCaseStudy.Model;
using HBCaseStudy.Model.Entities;

namespace HBCaseStudy.Business.Abstract.Factories
{
    public interface IOperationStrategy
    {
        void SetMovement(Rover rover, Movement movement);
    }
}